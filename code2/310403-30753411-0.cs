    public Form1()
    {
        InitializeComponent();
    
        backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;  //Tell the user how the process went
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.WorkerSupportsCancellation = true; //Allow for the process to be cancelled
    }
    
    //Start Process
    private void button1_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync();
    }
    
    //Cancel Process
    private void button2_Click(object sender, EventArgs e)
    {
        //Check if background worker is doing anything and send a cancellation if it is
        if (backgroundWorker1.IsBusy)
        {
            backgroundWorker1.CancelAsync();
        }
    
    }
    
    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(1000);
            backgroundWorker1.ReportProgress(i);
            //Check if there is a request to cancel the process
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                backgroundWorker1.ReportProgress(0);
                return;
            }
        }
        //If the process exits the loop, ensure that progress is set to 100%
        //Remember in the loop we set i < 100 so in theory the process will complete at 99%
        backgroundWorker1.ReportProgress(100);
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }
    
    private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
             lblStatus.Text = "Process was cancelled";
        }
        else if (e.Error != null)
        {
             lblStatus.Text = "There was an error running the process. The thread aborted";
        }
        else
        {
           lblStatus.Text = "Process was completed";
        }
    }
