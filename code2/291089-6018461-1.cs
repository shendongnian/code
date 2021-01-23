    var finished = new CountdownEvent(1); // Used to wait for the completion of all work items.
    var throttle = new Semaphore(3, 3); // Used to throttle the processing of work items.
    foreach (WorkItem item in workitems)
    {
      finished.AddCount();
      WorkItem capture = item; // Needed to safely capture the loop variable.
      ThreadPool.QueueUserWorkItem(
        (state) =>
        {
          throttle.WaitOne();
          try
          {
            ProcessWorkItem(capture);
          }
          finally
          {
            throttle.Release();
            finished.Signal();
          }
        }, null);
    }
    finished.Signal();
    finished.Wait();
