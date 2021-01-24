    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Get the BackgroundWorker that raised this event.
        BackgroundWorker worker = sender as BackgroundWorker;
        for (int i = 0; i < (int)e.Argument; i++)
        {
            if (Running)
            {
                //Do work
                Thread.Sleep(10);  
                //Report Progress
                worker.ReportProgress(i);
            }
        }
    }
