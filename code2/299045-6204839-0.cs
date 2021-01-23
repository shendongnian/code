    public Form1()
    {
        bw1.WorkerReportsProgress = true;
        bw1.ProgressChanged += bw1_ProgressChanged;
        bw1.DoWork += bw1_DoWork;
    
        bw1.RunWorkerAsync();
    }
    
    private void bw1_DoWork(object sender, DoWorkEventArgs e)
    {
        var worker = sender as BackgroundWorker;
    
        while (workNotDone)
        {
            //Do whatever work
            worker.ReportProgress(CalculateProgressDonePercentage());
        }
    }
    
    private void bw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        //This is called on GUI/main thread, so you can access the controls properly
        progressBar.Value = e.ProgressPercentage;
    }
