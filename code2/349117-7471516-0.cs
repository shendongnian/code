    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        for (int i = 1; i <= 100; i++)
        {
            // Wait 100 milliseconds.
            Thread.Sleep(100);
            
            if (backgroundWorker1.CancellationPending == true)
            {
                e.Cancel = true;
                break;
            }
            // Report progress.
            backgroundWorker1.ReportProgress(i);
        }
    }
