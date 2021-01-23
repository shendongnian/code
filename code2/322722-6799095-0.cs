    namespace WindowsFormsApplication1
    {
        using System;
        using System.ComponentModel;
        using System.Windows.Forms;
        using System.Management;
        public partial class Form1 : Form
        {
            private Timer Timer = new Timer();
            private BackgroundWorker bgw = new BackgroundWorker();
            public Form1()
            {
                InitializeComponent();
                Timer.Interval = 2000;
                Timer.Tick += Timer_Tick;
                bgw.DoWork += bgw_DoWork;
                bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
            }
            void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                {
                    Timer.Stop();
                    MessageBox.Show(((Exception)e.Result).ToString());
                }
                else
                {
                    var result = (UInt16)e.Result;
                    listBox1.Items.Add(result.ToString());
                }
            }
            static void bgw_DoWork(object sender, DoWorkEventArgs e)
            {
                try
                {
                    ManagementObjectSearcher searcher =
                                    new ManagementObjectSearcher("root\\CIMV2",
                                    "SELECT * FROM Win32_Processor");
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        e.Result = (UInt16)queryObj["LoadPercentage"];
                        return;
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            }
            void Timer_Tick(object sender, EventArgs e)
            {
                if (bgw.IsBusy == false)
                {
                    bgw.RunWorkerAsync();
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Timer.Start();
            }
        }
    }
