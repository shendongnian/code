    BackgroundWorker worker = sender as BackgroundWorker;
    for (int i = 0;i <= 10; i++)
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
            
            worker.ReportProgress((i * 10));
            
            if(i == 100) i = 0;
        }
    }
