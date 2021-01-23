    public class SomeModule
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private IDataReceiver _receiver;
        public SomeModule(IDataReceiver receiver)
        {
            // attach event handlers to the background worker
            _worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
            // store a reference to the receiver
            _receiver = receiver;
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
            e.Result = "some data";
        }
    }
