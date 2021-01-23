    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                // Set the background worker to allow the user to stop the process. 
                backgroundWorkerStopCheck.WorkerSupportsCancellation = true;
                backgroundWorkerStopCheck.DoWork += new DoWorkEventHandler(backgroundWorkerStopCheck_DoWork);
            }
    
            private void backgroundWorkerStopCheck_DoWork(object sender, DoWorkEventArgs e)
            {
                try
                {
                    for (int i = 0; i < 50; i++)
                    {
                        if (backgroundWorkerStopCheck.CancellationPending)
                        {
                            // user cancel request
                            e.Cancel = true;
                            return;
                        }
                        
                        System.Threading.Thread.Sleep(100);
                    }
                }
                finally
                {
                    InvokeEnableStartButton();
                }
            }
    
            private void buttonStart_Click(object sender, EventArgs e)
            {
                //disable start button before launch work
                buttonStart.Enabled = false;
    
                // start worker
                backgroundWorkerStopCheck.RunWorkerAsync();
            }
    
            private void buttonStop_Click(object sender, EventArgs e)
            {
                // Tell the backgroundWorker to stop process.
                backgroundWorkerStopCheck.CancelAsync();
            }
    
            private void InvokeEnableStartButton()
            {
                // this method is called from a thread,
                // we need to Invoke to avoid "cross thread exception"
                if (this.InvokeRequired)
                {
                    this.Invoke(new EnableStartButtonDelegate(EnableStartButton));
                }
                else
                {
                    EnableStartButton();
                }
            }
    
            private void EnableStartButton()
            {
                buttonStart.Enabled = true;
            }
        }
    
        internal delegate void EnableStartButtonDelegate();
    }
