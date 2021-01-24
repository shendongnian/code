    static async Task Main(string[] args)
    {
       var ts = new CancellationTokenSource();
    
       Console.WriteLine("Press key to cancel tasks");
       var task = DoFunkyStuff(ts.Token);
    
       // user input
       Console.ReadKey();
    
       Console.WriteLine("Cancelling token");
    
       // this is how to cancel
       ts.Cancel();
    
       // just to prove the task has been cancelled
       await task;
    
       // because i can
       Console.WriteLine("Elvis has left the building");
       Console.ReadKey();
    }
