    try 
    {
      var task = new Task(() => DoParallel());
      task.Start();
      task.Wait();
    }
    catch (AggregateException ex)
    {
      // Reachable code
    }
 
