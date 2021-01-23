            void Go()
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.RunWorkerAsync();
            }
    
            void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressBar_ChangeProgress.Value = e.ProgressPercentage;
            }
    
            void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                for (int b = 0; b < 100; b++) 
                {
                    Thread.Sleep(100);
                    worker.ReportProgress(b);
                }
            }
