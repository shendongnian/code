    int pending = table.Rows.Count;
    var finished = new ManualResetEvent(false);
    foreach (DataRow row in table.Rows)
    {
      DataRow capture = row; // Required to close over the loop variable correctly.
      ThreadPool.QueueUserWorkItem(
        (state) =>
        {
          try
          {
            ProcessDataRow(capture);
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
