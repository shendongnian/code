    static async Task Main(string[] args)
    {
       var ts = new CancellationTokenSource();
    
       var messages = GetRealTimeMessage();
       var tasks = messages.Select(x => ProcessMessage(x, ts.Token));
    
       await Task.WhenAll(tasks);
    
       Console.ReadLine();
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
       catch (OperationCanceledException )
       {
          Console.WriteLine("Operation Cancelled");
       }
       catch (Exception)
       {
          Console.WriteLine("Critical error");
       }
    }
