    public class SomeModule
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private IDataReceiver _receiver;
        public SomeModule(IDataReceiver receiver)
        {
            _worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
            _worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
            _worker.WorkerReportsProgress = true;
            _receiver = receiver;
        }
        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _receiver.SetData(e.UserState.ToString());
        }
        public void DoSomeWork()
        {
            // start the worker
            _worker.RunWorkerAsync();
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // call method to pass data to receiver
            _receiver.SetData(e.Result.ToString());
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // do some work here
            // assign the resulting data to e.Result
            for (int i = 0; i < 10; i++)
            {
                _worker.ReportProgress(0, "some data " + i);
                Thread.Sleep(250);
            }
            e.Result = "Finished";
        }
    }
