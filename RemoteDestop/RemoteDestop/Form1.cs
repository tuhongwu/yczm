using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MSTSCLib;

namespace RemoteDestop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jsj = txtname.Text.Trim();
            string user = txtUser.Text.Trim();
            string pwd = txtPwd.Text.Trim();

            if (string.IsNullOrEmpty(jsj) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("所填项目不能为空！");
                return;
            }
            //Thread start = new Thread(() =>
            //{
            try
            {
                rdp.Server = jsj;// "192.168.9.141";
                rdp.UserName = user;// "Matt";// "administrator";
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = pwd;// "zeda";
                rdp.DesktopHeight = 630;
                rdp.DesktopWidth = panel1.Width;// 950;

                rdp.Connect();
                //MessageBox.Show("成功");
            }
            catch (Exception)
            {
                MessageBox.Show("无法连接");
            }
            //});
            //start.IsBackground = true;
            //start.Start();
            //MessageBox.Show("成功");
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFull_Click(object sender, EventArgs e)
        {
            //this.rdp.FullScreen = !this.rdp.FullScreen;
            //this.rdp.FullScreenTitle = "aa";
            if (rdp.Connected.ToString() == "1")
                rdp.Disconnect();


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
