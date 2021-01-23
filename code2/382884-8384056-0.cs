        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        using System.Threading;
        using System.Threading.Tasks;
        using System.Runtime.Remoting.Messaging;
        namespace InvokeTest
        {
        public partial class frm_Main : Form
        {
        private delegate void dgt_StringHandler(string str_Value);
        CancellationTokenSource _obj_Cts = null;
        Thread _obj_Thread = null;
        Task _obj_Task = null;
        IAsyncResult _obj_Ar = null;
        public frm_Main()
        {
            InitializeComponent();
        }
        private void CreateChar(ref char chr_Value)
        {
            int int_Value;
            int_Value = (int)chr_Value;
            int_Value++;
            if (int_Value > 90 || int_Value < 65)
                int_Value = 65;
            chr_Value = (char)int_Value;
        }
        private void TestThread()
        {
            char chr_Value = '@';
            bool bol_Stop = false;
            while (!bol_Stop)
            {
                try
                {
                    Thread.Sleep(1); // is needed for interrupting the thread
                    CreateChar(ref chr_Value);
                    RefreshTextBox(chr_Value.ToString());
                }
                catch (ThreadInterruptedException)
                {
                    bol_Stop = true;
                }
            }
        }
        private void TestTask(object obj_TokenTmp)
        {
            char chr_Value = '@';
            CancellationToken obj_Token = (CancellationToken)obj_TokenTmp;
            while (!obj_Token.IsCancellationRequested)
            {
                CreateChar(ref chr_Value);
                RefreshTextBox(chr_Value.ToString());
            }
        }
        private void RefreshTextBox(string str_Value)
        {            
            if (txt_Value.InvokeRequired)
            {
                if (_obj_Ar == null ||
                    _obj_Ar.IsCompleted)
                {
                    dgt_StringHandler obj_StringHandler = new dgt_StringHandler(RefreshTextBox);
                    _obj_Ar = this.BeginInvoke(obj_StringHandler, new object[] { str_Value });
                }
            }
            else
            {
                Thread.Sleep(200);
                txt_Value.Text = str_Value;
            }
        }
        private void btn_StartStop_Click(object sender, EventArgs e)
        {
            if (_obj_Task == null && _obj_Thread == null)
            {
                if (opt_Task.Checked)
                {
                    _obj_Cts = new CancellationTokenSource();
                    _obj_Task = new Task(new Action<object>(TestTask), _obj_Cts.Token, _obj_Cts.Token);
                    _obj_Task.Start();
                }
                else
                {
                    _obj_Thread = new Thread(new ThreadStart(TestThread));
                    _obj_Thread.Start();
                }
                btn_StartStop.Text = "Stop";
            }
            else
            {
                if (_obj_Thread != null)
                {
                    _obj_Thread.Interrupt();
                    _obj_Thread.Join();
                    _obj_Thread = null;
                }
                if (_obj_Task != null)
                {
                    _obj_Cts.Cancel();
                    _obj_Task.Wait();
                    _obj_Task = null;
                    _obj_Cts = null;
                }
                
                btn_StartStop.Text = "Start";
            }
        }
        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_obj_Thread != null)
            {
                _obj_Thread.Interrupt();
                _obj_Thread.Join();
            }
            if (_obj_Task != null)
            {
                _obj_Cts.Cancel();
                _obj_Task.Wait();
            }
        }
        }
        }
