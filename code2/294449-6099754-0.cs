        public MainForm()
        {
            InitializeComponent();
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = false;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new  RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            unitsToolStripLabel.Text = "Loading Units";
            bw.RunWorkerAsync();
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ...
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            unitsToolStripLabel.Text = string.Format("{0} Units Loaded", Units.UnitLibrary.WorkingSet.Count);
            unitsToolStripLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            unitsToolStripLabel.Click += new EventHandler(unitsToolStripLabel_Click);
        }
