public partial class Form1 : Form
    {
        private bool capturing = false;
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
  // Don't need to re-bind
            //backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            //backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            //backgroundWorker1.WorkerSupportsCancellation = true;
        }
private void captureBtn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button clicked");
            if (capturing) { return; }
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void stopCaptureBtn_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            capturing = true;
            Debug.WriteLine("DoWork running");
            int frames = 1;
            while (!backgroundWorker1.CancellationPending)
            {
                Debug.WriteLine("Capturing frame {0}", frames);
                //do the capturing to memory stream
                frames++;
            }
            Debug.WriteLine("DoWork cancelled");
            //do some other things like saving the gif etc
            //e.Result = someResult;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("RunWorkerCompleted running");
            capturing = false;
            //does something with the e.Result
        }
