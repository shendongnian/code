        public int ProgressBarPercentage { get; set; }
        public string StatusMessage { get; set; }
        public void StartDownload()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Run clean up code here once complete (ie make sure progress bar is at 100 percent....
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            // Download files here
            List<string> filestoget = new List<string>();
            filestoget.Add("File1");
            filestoget.Add("File2");
            filestoget.Add("File3");
            filestoget.Add("File4");
            filestoget.Add("File5");
            foreach (string file in filestoget)
            {
                // Get File
                // Report output
                int progress = 0; // add soemthing here to calculate your progress
                bw.ReportProgress(progress, string.Format("File {0} downloaded", file));
            }
        }
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarPercentage = e.ProgressPercentage;
            StatusMessage = e.UserState.ToString();
        }
