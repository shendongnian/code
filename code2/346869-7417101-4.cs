    CancellationToken token = new CancellationToken();            
    SemaphoreSlim semaphore = new SemaphoreSlim(1,1);
                
    try {
       // block section entrance for other threads
       semaphore.Wait(token);
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
