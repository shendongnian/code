        public Form1()
        {
            InitializeComponent();
            m_Worker.DoWork += new DoWorkEventHandler(m_Worker_DoWork);
            m_Worker.ProgressChanged += new ProgressChangedEventHandler(m_Worker_ProgressChanged);
            m_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_Worker_RunWorkerCompleted);
        }
        void m_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Usually, used to update a progress bar
        }
        void m_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Usually, used to add some code to notify the user that the job is done.
        }
        void m_Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        //e.Argument.ToString() contains the path to the file
        //Do what you want with the file returned.
    }        
    private void bOpen_Click(object sender, EventArgs e)
    {
        OpenFileDialog d = new OpenFileDialog();
        if (d.ShowDialog() == DialogResult.OK)
        {
            m_Worker.RunWorkerAsync(d.FileName);    
        }            
    }
        BackgroundWorker m_Worker = new BackgroundWorker();
    }
