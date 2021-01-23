    private void LaunchWorker()
    {
        var worker = new BackgroundWorker();
        worker.DoWork += new DoWorkEventHandler(OnDoWork);
        worker.ProgressChanged += new ProgressChangedEventHandler(OnProgressChanged);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnRunWorkerCompleted);
        worker.RunWorkerAsync();
    }
    void OnDoWork(object sender, DoWorkEventArgs e)
    {
        var worker = sender as BackgroundWorker;
        while (aLongTime)
        {
            worker.ReportProgress(percentageDone, partialResults);
        }
        e.Result = results;
    }
    void OnProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var progress = e.ProgressPercentage;
        var partialResults = e.UserState;
        // Update UI based on progress
    }
    void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        var results = e.Result;
        // Do something with results
    }
