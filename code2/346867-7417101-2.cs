    CancellationToken token = new CancellationToken();            
    SemaphoreSlim semaphore = new SemaphoreSlim(1,1);
                
    // block section entrance for other threads
    semaphore.Wait(token);
    try {
       // critical section code
       // ...
       if (token.IsCancellationRequested)
       {
           // ...
       }
    }
    finally { 
       semaphore.Release();
    }
