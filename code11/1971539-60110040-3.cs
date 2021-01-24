    public static async Task DoFunkyStuff(CancellationToken token)
    {
       // a logical escape for the loop
       while (!token.IsCancellationRequested)
       {
          try
          {
             Console.WriteLine("Waiting");
             await Task.Delay(1000, token);
          }
          catch (OperationCanceledException e)
          {
             Console.WriteLine("Task Cancelled");
          }
       }
       Console.WriteLine("Finished");
    }
    
