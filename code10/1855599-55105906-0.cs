    public partial class CheckConnectivityPopup : MetroWindow
    {
        public readonly BackgroundWorker worker = new BackgroundWorker();
        public SemaphoreSlim doneEvent = new SemaphoreSlim(0, 1);
        public Status status = null;
        public CheckConnectivityPopup()
        {
            InitializeComponent();
            this.Show();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //displayAndCheck();
            status = CheckStatus();
            Thread.Sleep(10000); // to simulate the time
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            doneEvent.Release();
            this.Close();
        }
    }
