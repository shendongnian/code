    using System;
    using System.Threading.Tasks;
    using System.Threading;
     
    namespace CancelTask
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Press 1 to cancel task");
                var cTokenSource = new CancellationTokenSource();
                // Create a cancellation token from CancellationTokenSource
                var cToken = cTokenSource.Token; 
                // Create a task and pass the cancellation token
                var t1 = Task<int>.Factory.StartNew(() 
                    => GenerateNumbers(cToken), cToken);
     
                // to register a delegate for a callback when a 
                // cancellation request is made
                cToken.Register(() => cancelNotification());
     
                // If user presses 1, request cancellation.
                if (Console.ReadKey().KeyChar == '1')
                {
                    // cancelling task
                    cTokenSource.Cancel();
                }
                Console.ReadLine();
            }
     
            static int GenerateNumbers(CancellationToken ct)
            {
                int i;
                for (i = 0; i < 10; i++)
                {
                    Console.WriteLine("Method1 - Number: {0}", i);
                    Thread.Sleep(1000);
                    // poll the IsCancellationRequested property
                    // to check if cancellation was requested
                    if (ct.IsCancellationRequested)
                    {
                        break;
                    }
     
                }
                return i;
            }
     
            // Notify when task is cancelled
            static void cancelNotification()
            {
                Console.WriteLine("Cancellation request made!!");
            }
        }
    }
