        BackgroundWorker worker;
        public Form1()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Collect data and open your second form here;
        }
