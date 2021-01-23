    var tasks = new List<Task>();
    foreach (DataRow row in table.Rows)
    {
      DataRow capture = row; // Required to close over the loop variable correctly.
      tasks.Add(
        Task.Factory.StartNew(
          () =>
          {
            ProcessDataRow(capture);        
          }));
    }
    Task.WaitAll(tasks.ToArray()); // Wait for all work items to complete.
