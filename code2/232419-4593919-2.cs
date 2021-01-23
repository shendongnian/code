    class Program
    {
        static void Main(string[] args)
        {
            var asyncFunc = new Action<int>(i =>
                {
                    Thread.Sleep((i+1) * 1000);
                    Console.WriteLine("Called {0}!", i);
                });
            var requests = Enumerable.Range(0, 5)
                                     .Select(i =>
                // wrap asynchronous call in a task
                Task.Factory.FromAsync(asyncFunc.BeginInvoke, asyncFunc.EndInvoke, i, asyncFunc))
                                     .ToArray();
            // wait (block) until all tasks complete
            Task.WaitAll(requests);
            // do "mainCallback" now
            Console.WriteLine("All called!");
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
