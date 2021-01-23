    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        for (var i = 0; i < 1000; i++)
        {
            backgroundWorker1.ReportProgress(i);
        }
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        Console.WriteLine(e.ProgressPercentage);
    }
