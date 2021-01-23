    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Threading;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm());
        }
    }
    class MyForm : Form
    {
        Button btn;
        BackgroundWorker worker;
        ProgressBar bar;
        public MyForm()
        {
            Controls.Add(btn = new Button { Text = "Click me" });
            btn.Click += new EventHandler(btn_Click);
            
            Controls.Add(bar = new ProgressBar { Dock = DockStyle.Bottom });
            worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int count = 0; count < 100; count++)
            {
                worker.ReportProgress(count);
                Thread.Sleep(50);
            }
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            bar.Value = e.ProgressPercentage;
        }
        void btn_Click(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }
    }
