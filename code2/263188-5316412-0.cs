    class Manager
    {
        public ObservableCollection<string> Reports { get; private set; }
        public void runWorkers(int numWorkers)
        {
            for (int i = 0; i < numWorkers; i++)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync(i);
            }
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Job((int)e.Argument);
        }
        public void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Reports.Add(e.Result as string);
        }
        private string Job(int jobID)
        {
            Thread.Sleep(2000);
            return string.Format("Job {0} Completed", jobID);
        }
    }
