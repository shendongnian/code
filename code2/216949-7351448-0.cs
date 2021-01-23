    CancellationTokenSource cancelSignal = new CancellationTokenSource();
    try
    {
        // do work
        List<Task> workerTasks = new List<Task>();
        foreach (Worker w in someArray)
        {
            workerTasks.Add(w.DoAsyncWork(cancelSignal.Token);
        }
        while (!Task.WaitAll(workerTasks.ToArray(), 100, cancelSignal.Token)) ;
     }
     catch (Exception)
     {
         cancelSignal.Cancel();
         throw;
     }
     
