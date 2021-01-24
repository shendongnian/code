    private void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
    {
        var worker = (BackgroundWorker)sender;
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(500);
            worker.ReportProgress(i * 10);
        }
    }
    private void OnBackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        labelProgress.Text = e.ProgressPercentage.ToString();
    }
    private void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        labelProgress.Text = "Done";
    }
    private void OnButtonProgressClick(object sender, System.EventArgs e)
    {
        backgroundWorker.RunWorkerAsync();
    }
