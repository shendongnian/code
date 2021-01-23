    public class Model : IModel
    {
        public event EventHandler<SampleEventArgs> Completed;
        public void LongRunningTask()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += this.bw_DoWork;
            bw.RunWorkerCompleted += this.bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.Completed != null)
            {
                this.Completed(this, new SampleEventArgs {Data = "Test"});
            }
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
        }
    }
