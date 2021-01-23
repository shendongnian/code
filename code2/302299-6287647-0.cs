    BackgroundWorker[] workers = new BackgroundWorker[10];
    bool allThreadsDone = false;
    
    for (int i = 0; i < 10; i++)
    {
            workers[i] = new BackgroundWorker();
            workers[i].WorkerSupportsCancellation = true;
            workers[i].RunWorkerCompleted += 
                new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            workers[i].DoWork += new DoWorkEventHandler(AlgorithmsUI_DoWork);
            workers[i].RunWorkerAsync();
    }
    
    void AlgorithmsUI_DoWork(object sender, DoWorkEventArgs e)
    {
          while (!stop)
                // do something        
    }
    
    private void  worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        bool threadsStillRunning = false;
        foreach (BackgroundWorker worker in workers)
        {
            if (worker.IsBusy)
            {
                threadsStillRunning = true;
            }
        }
        if (!threadsStillRunning)
            allThreadsDone = true;
    } 
