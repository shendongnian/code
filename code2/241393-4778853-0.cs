    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            private BackgroundWorker _bw = new BackgroundWorker { WorkerSupportsCancellation = true, 
                WorkerReportsProgress = true};
            public Form1()
            {
                InitializeComponent();
            
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                }
                else
                {
                    _bw.ProgressChanged += new ProgressChangedEventHandler(_bw_ProgressChanged);
                    _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
                    _bw.RunWorkerAsync();
                }
            }
    
            void _bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                textBox1.Text += (string)e.UserState;
            }
    
            void _bw_DoWork(object sender, DoWorkEventArgs e)
            {
                int count = 0;
                while (!_bw.CancellationPending)
                {
                    _bw.ReportProgress(0, string.Format("worker working {0}", count));
                    ++count;
                    Thread.Sleep(2000);
                }
            }
        }
    }
