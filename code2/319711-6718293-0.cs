    public partial class Form1 : Form
        {
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
                OpenFileDialog d = new OpenFileDialog();
                if (d.ShowDialog() == DialogResult.OK)
                {
                    //Do what you want with the file returned.
                }
            }        
    
            private void bOpen_Click(object sender, EventArgs e)
            {
                m_Worker.RunWorkerAsync();
            }
    
            BackgroundWorker m_Worker = new BackgroundWorker();
        }
