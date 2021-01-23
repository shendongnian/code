    public class Runner
    {
        private readonly BackgroundWorker _worker = new BackgroundWorker();
	
        public Runner()
        {
            _worker.DoWork += WorkerDoWork;
        }
        public void RunMe(int payload)
        {
            _worker.RunWorkerAsync(payload);
        }
        static void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            while (true)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
			
                // Work
                System.Threading.Thread.Sleep((int)e.Argument);
            }
        }
    }
