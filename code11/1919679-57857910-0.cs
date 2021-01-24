    public Form1()
    {
        InitializeComponent();
    
        backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        backgroundWorker1.WorkerReportsProgress = true;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync();
    }
    
    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        //Long-running process goes here
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(1000);
            backgroundWorker1.ReportProgress(i);
        }
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }
