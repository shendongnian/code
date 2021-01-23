    class Program
    {
        static void Main(string[] args)
        {
            var asyncFunc = new Action<int>(i =>
                {
                    Thread.Sleep((i+1) * 1000);
                    Console.WriteLine("Called {0}!", i);
                });
            var callback = new Action(() => Console.WriteLine("Callback called"));
            var requests = Enumerable.Range(0, 5)
                                     .Select(i =>
                                      {
                                          return Task.Factory
                                                      // wrap asynchronous call in a task
                                                     .FromAsync(asyncFunc.BeginInvoke, asyncFunc.EndInvoke, i, asyncFunc)
                                                      // register callback
                                                     .ContinueWith(_ => callback());
                                      })
                                     .ToArray();
            Task.WaitAll(requests);
            // do callback
            Console.WriteLine("All called!");
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
