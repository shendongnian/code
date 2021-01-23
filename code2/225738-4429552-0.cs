    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Test
    {
        static void Main()
        {
            var cts = new CancellationTokenSource();
            Console.WriteLine("Creating task...");
            Task task = new Task(() => Console.WriteLine("Task executing"),
                                 cts.Token);
            Console.WriteLine("Sleeping...");
            Thread.Sleep(1000);
            Console.WriteLine("Starting task...");
            task.Start();
            Thread.Sleep(1000);
        }
    }
