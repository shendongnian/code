    var finished = new CountdownEvent(1);
    foreach (object A in myCollection) 
    {
      var capture = A; // Required to close over the loop variable 
      finished.AddCount(); // Indicate that there is another work item
      ThreadPool.QueueUserWorkItem(
        (state) =>
        {
          try
          {
            capture.process();
          }
          finally
          {
            finished.Signal(); // Signal work item is complete
          }
        }, null);
    } 
    finished.Signal(); // Signal queueing is complete
    finished.Wait(); // Wait for all work items
