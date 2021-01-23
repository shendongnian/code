    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
    
        for (int i = 1; (i <= 10); i++)
        {
            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
                break;
            }
            else
            {
                // Perform a time consuming operation and report progress.
                System.Threading.Thread.Sleep(500);
                worker.ReportProgress((i * 10)); //Activating the progressChanged event
            }
        }
    }
