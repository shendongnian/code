    BackgroundWorker bw = new BackgroundWorker();
    bw.WorkerSupportsCancellation = true;
    bw.WorkerReportsProgress = true;
    .
    .
    .
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        for (;;)
        {
            if (worker.CancellationPending == true)
            {
               e.Cancel = true;
            
               break;
            }
            
            else
            {
                // Perform a time consuming operation and report progress.
            
                System.Threading.Thread.Sleep(100);
            }
        }
    }
