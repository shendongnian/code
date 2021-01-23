    public abstract class AsyncTask
    {
        private BackgroundWorker bw;
        public AsyncTask()
        {
            bw = new BackgroundWorker();
            bw.DoWork += (s,e)=> { DoInBackground(); };
            bw.RunWorkerCompleted += (s, e) => { TaskCompleted(); };
        }
        
        protected abstract void PreExecute();
        protected abstract void DoInBackground();
        protected abstract void TaskCompleted();
        public void Execute() {
            PreExecute();
            bw.RunWorkerAsync();
        }
    }
