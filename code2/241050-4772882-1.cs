    public partial class Form1 : Form
    {
        private BackgroundWorker backgroundWorker;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.DoWork += HandleBackgroundWorkerOnDoWork;
            this.backgroundWorker.RunWorkerCompleted += HandleBackgroundWorkerOnRunWorkerCompleted;
            this.backgroundWorker.WorkerSupportsCancellation = true;
        }
    
        private void HandleDataRequest()
        {
            // show UI notification...
            BackgroundWorkUINotification backgroundWorkUINotification = new BackgroundWorkUINotification();
            backgroundWorkUINotification.CancelClicked += HandleBackgroundWorkUINotificationOnCancelClicked;
            backgroundWorkUINotification.Show(this);
    
            // start the background worker 
            this.backgroundWorker.RunWorkerAsync();
        }
    
        private void HandleBackgroundWorkUINotificationOnCancelClicked(Object sender, EventArgs e)
        {
            // UI notification Form, Cancelled
            // close the form...
            BackgroundWorkUINotification backgroundWorkUINotification = (BackgroundWorkUINotification)sender;
            backgroundWorkUINotification.Close();
    
            // stop the background worker thread...
            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
        }
    
        private void HandleBackgroundWorkerOnRunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
    
        private void HandleBackgroundWorkerOnDoWork(Object sender, DoWorkEventArgs e)
        {
            // do some work here..
            // also check for CancellationPending property on BackgroundWorker
        }
    }
