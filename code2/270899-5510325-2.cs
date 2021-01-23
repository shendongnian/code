        BackgroundWorker m_objWorker = new BackgroundWorker();
        public FormBackgroundWorkerExample()
        {
            InitializeComponent();
            m_objWorker.WorkerReportsProgress = true;
            m_objWorker.DoWork += new DoWorkEventHandler(m_objWorker_DoWork);
            m_objWorker.ProgressChanged += new ProgressChangedEventHandler(m_objWorker_ProgressChanged);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            m_objWorker.RunWorkerAsync();
        }
        private void m_objWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //for each folder in list perform this function, which scans folder and gets all files
            for (int i = 0; i <= 100; i++)
            {
                m_objWorker.ReportProgress(i, "FooBar");
                Thread.Sleep(1000);
            }
        }
        private void m_objWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            dataGridView1.Rows.Add(e.UserState.ToString()); 
        }
