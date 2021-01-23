    var finished = new CountdownEvent(1);
    for (int i = 0; i < NUM_WORK_ITEMS; i++)
    {
      finished.AddCount();
      SpawnAsynchronousOperation(
        () =>
        {
          try
          {
            // Place logic to run in parallel here.
          }
          finally
          {
            finished.Signal();
          }
        }
    }
    finished.Signal();
    finished.Wait();
