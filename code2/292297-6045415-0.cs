        public void UseBackgroundWorker()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += DoWork;
            worker.RunWorkerCompleted += WorkDone;
            worker.RunWorkerAsync("input");
        }
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument.Equals("input");
            Thread.Sleep(1000);
        }
        public void WorkDone(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = (bool) e.Result;
        }
