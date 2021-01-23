    public double TimeCall(Action actionToExecute)
    {
       double elapsed = 0;
    
       if (actionToExecute != null)
       {
          var stopwatch = Stopwatch.StartNew();
          actionToExecute.Invoke();
          elapsed = stopwatch.ElapsedMilliseconds;
       }
    
       return elapsed;
    }
