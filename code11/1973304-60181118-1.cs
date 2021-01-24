    static async Task Main(string[] args)
    {
       var ts = new CancellationTokenSource();
    
       var messages = GetRealTimeMessage();
       var tasks = messages.Select(x => ProcessMessage(x, ts.Token));
    
       Console.WriteLine("Press any key to cancel tasks")
       Console.ReadKey();
    
       ts.Cancel();
       await Task.WhenAll(tasks);
       Console.WriteLine("All finished");
       Console.ReadKey(); 
    }
    
    private static async Task ProcessMessage( RealTimeMessage message, CancellationToken token )
    {
       try
       {
          while (!token.IsCancellationRequested)
          {
             await Task.Delay(TimeSpan.FromSeconds(60), token);
             ProcessRequest(message);
          }
       }
       catch (OperationCanceledException)
       {
          Console.WriteLine("Operation Cancelled");
       }
       catch (Exception ex)
       {
          Console.WriteLine("Critical error: " +  ex.Message);
       }
    }
