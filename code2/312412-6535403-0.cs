    using (var finished = new CountdownEvent(1))
    {
      foreach (var workitem in workitems)
      {
        var capture = workitem; // Used to capture the loop variable in the lambda expression.
        finished.AddCount(); // Indicate that there is another work item.
        ThreadPool.QueueUserWorkItem(
          (state) =>
          {
            try
            {
              ProcessWorkItem(capture);
            }
            finally
            {
              finished.Signal(); // Signal that the work item is complete.
            }
          }, null);
      }
      finished.Signal(); // Signal that queueing is complete.
      finished.Wait(); // Wait for all work items to complete.
    }
