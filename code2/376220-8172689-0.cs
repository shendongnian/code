    int pending = requests.Count;
    var finished = new ManualResetEvent(false);
    foreach (Request request in requests)
    {
      Request capture = request; // Required to close over the loop variable correctly.
      ThreadPool.QueueUserWorkItem(
        (state) =>
        {
          try
          {
            ProcessRequest(capture);
          }
          finally
          {
             if (Interlocked.Decrement(ref pending) == 0) 
             {
               finished.Set();  // Signal completion of all work items.
             }
          }
        }, null);
    }
    finished.WaitOne(); // Wait for all work items to complete.
