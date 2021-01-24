    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp2
    {
      public static class Program
      {
        public static async Task Main(string[] args)
        {
          using (var cts = new CancellationTokenSource())
          {
            CancellationToken token = cts.Token;
    
            // start the asyncronous operation
            Task<string> getMessageTask = GetSecretMessage(token);
    
            // request the cancellation of the operation
            cts.Cancel();
    
    
            try
            {
              string message = await getMessageTask.ConfigureAwait(false);
              Console.WriteLine($"Operation completed successfully before cancellation took effect. The message is: {message}");
            }
            catch (OperationCanceledException)
            {
              Console.WriteLine("The operation has been canceled");
            }
            catch (Exception)
            {
              Console.WriteLine("The operation completed with an error before cancellation took effect");
              throw;
            }
    
          }
        }
    
        static async Task<string> GetSecretMessage(CancellationToken cancellationToken)
        {
          // simulates asyncronous work. notice that this code is listening for cancellation
          // requests
          await Task.Delay(500, cancellationToken).ConfigureAwait(false);
          return "I'm lost in the universe";
        }
      }
    }
