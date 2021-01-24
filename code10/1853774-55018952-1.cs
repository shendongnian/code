    private void DoBackGroundWork(object sender, DoWorkEventArgs e)
    {
        var backgroundWorker = (BackgroundWorker)sender;
        While(!backgroundWorker.CancellationPending)
        {
            // continue producing output
            var producedOutput = ...
            // report that new output is available:
            backgroundWorker.ReportProgress(0, producedOutput);
        }
    }
