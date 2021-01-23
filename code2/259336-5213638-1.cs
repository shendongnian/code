    private BackgroundWorker bw = new BackgroundWorker();
    
    public Form1()
    {
        InitializeComponent();
        bw.WorkerReportsProgress = true;
        bw.WorkerSupportsCancellation = true;
        bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
    }
    
    public void buttonStart_Click(object sender, EventArgs e)
    {
        if (bw.IsBusy != true)
            bw.RunWorkerAsync(12); //Start
    }
    
    public int Pils(int i)
    {
        Thread.Sleep(2000);
        bw.ReportProgress(70, "In the middle of the work..");
        Thread.Sleep(2000);
        bw.ReportProgress(90, "Returning the result..");
        Thread.Sleep(2000);
        return (2 * i);
    }
    
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        bw.ReportProgress(20, "Waiting for cancel.."); 
        Thread.Sleep(2000);
        if ((bw.CancellationPending == true))
            e.Cancel = true;
        else
        {
            bw.ReportProgress(50, "Starting process..");
            e.Result = Pils((int)e.Argument);
        }
    }
    
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        bw.ReportProgress(100, "Work done.."); 
        if ((e.Cancelled == true))
             textBox1.Text = "Canceled!";
        else if (e.Error != null)
             textBox1.Text = ("Error: " + e.Error.Message);
        else textBox1.Text = e.Result.ToString();
    }
    
    private void buttonCancel_Click(object sender, EventArgs e)
    {
        if (bw.WorkerSupportsCancellation == true)
            bw.CancelAsync();
    }
    
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        listBox1.Items.Add((e.ProgressPercentage.ToString() + "%") + " - " + e.UserState as String);
    }
