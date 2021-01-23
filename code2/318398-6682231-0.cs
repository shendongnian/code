    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Test
    {
        static void Main()
        {
            Task sleeper = Task.Factory.StartNew(() => Thread.Sleep(100000));
            
            int index = Task.WaitAny(new[] { sleeper },
                                     TimeSpan.FromSeconds(0.5));
            Console.WriteLine(index); // Prints -1, timeout
            
            var cts = new CancellationTokenSource();
            
            // Just a simple wait of getting a cancellable task
            Task cancellable = sleeper.ContinueWith(ignored => {}, cts.Token);
            
            // It doesn't matter that we cancel before the wait
            cts.Cancel();
            
            index = Task.WaitAny(new[] { cancellable },
                                 TimeSpan.FromSeconds(0.5));
            Console.WriteLine(index); // 0 - task 0  has completed (ish :)
            Console.WriteLine(cancellable.Status); // Cancelled
        }
    }
