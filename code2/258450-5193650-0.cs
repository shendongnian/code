        public Form1()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
        }
        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i < 101; ++i)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    //Sort Logic is in here.
                    Thread.Sleep(250);
                    backgroundWorker.ReportProgress(i);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy && backgroundWorker.WorkerSupportsCancellation)
                backgroundWorker.CancelAsync();
        }
