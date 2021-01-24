c#
    private static void End()
    {
      Console.WriteLine("EXITING...");
      if (Debugger.IsAttached)
          Environment.Exit(1); // this is equal to using CTRL+C in the terminal
    }
also, you should use a cancelation token to cleanly cancel your running tasks before application termination.
c#
 class Program
    {
        private static CancellationTokenSource tokenSource;
        static async Task Main(string[] args)
        {
            tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            Console.CancelKeyPress += (o, e) => End(); 
            await Task.Run(() => Task.Delay(100000), token);
        }
        private static void End()
        {
            Console.WriteLine("EXITING...");
            tokenSource.Cancel();
            tokenSource.Dispose();
            if (Debugger.IsAttached)
                Environment.Exit(1);
        }
    }
