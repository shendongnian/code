    public partial class Form1 : Form
    {
        enum states
        {
            Message1,
            Message2
        }
        BackgroundWorker worker;
        public Form1()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Fake some work, report progress
            worker.ReportProgress(0, states.Message1);
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            states state = (states)e.UserState;
            if (state == states.Message1) MessageBox.Show("This should hold the form");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }
    }
