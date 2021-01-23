        {
            progressBar1.Value = 1;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            var bgw = new BackgroundWorker();
            bgw.ProgressChanged += bgw_ProgressChanged;
            bgw.DoWork += bgw_DoWork;
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            // do your long running operation here
            for (int idx = 1; idx <= 100; idx++)
                // when using PerformStep() the percentProgress arg is redundant
                ((BackgroundWorker)sender).ReportProgress(0); 
        }
        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.PerformStep();
        }
