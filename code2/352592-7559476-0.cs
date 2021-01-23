    int pending = sites.Count;
    var finished = new ManualResetEvent(false);
    var semaphore = new Semaphore(5, 5);
    foreach (string site in sites)
    {
      semaphore.WaitOne();
      ThreadPool.QueueUserWorkItem(
        (state) =>
        {
          try
          {
            // Process your work item here.
          }
          finally
          {
            semaphore.Release();
            if (Interlocked.Decrement(ref pending) == 0)
            {
              finished.Set(); // This is the last work item.
            }
          }
        }, null);
    }
    finished.WaitOne(); // Wait for all work items to complete.
