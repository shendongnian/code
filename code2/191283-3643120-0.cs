            private BackgroundWorker _worker;
        public Form1()
        {
            InitializeComponent();
            _worker = new BackgroundWorker();
            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Work_Completed;
        }
        private void Work_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            txtOutput.Text = e.Result.ToString();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = "Text received from long runing operation";
        }
