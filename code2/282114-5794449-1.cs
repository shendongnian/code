        public Form1()
        {
            InitializeComponent();
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            object paramObj = 1;
            object paramObj2 = 2;
            // The parameters you want to pass to the do work event of the background worker.
            object[] parameters = new object [] { paramObj, paramObj2 };
            // This runs the event on new background worker thread.
            worker.RunWorkerAsync(parameters);
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] parameters = e.Argument as object[];
            // do something.
            e.Result = true;
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object result = e.Result;
            // Handle what to do when complete.                        
        }
