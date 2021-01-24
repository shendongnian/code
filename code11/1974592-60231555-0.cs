        public static async Task Main()
        {
            Console.WriteLine("Beginning Test");
            Console.WriteLine("Calling RunningAsync");
            Console.WriteLine("1 " + Thread.CurrentThread.ManagedThreadId);
            await RunningAsync();
            Console.WriteLine("2 " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("In outer method, after calling async method");
            Console.WriteLine("Exiting Test");
        }
        private static async Task RunningAsync()
        {
            Console.WriteLine("RunningAsync: Enter Method");
            Console.WriteLine("RunningAsync: Calling and awaiting inner running");
            Console.WriteLine("3 " + Thread.CurrentThread.ManagedThreadId);
            await InnerRunning();
            Console.WriteLine("4 " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("RunningAsync: Returning");
        }
        private static async Task InnerRunning()
        {
            Console.WriteLine("InnerRunning: Begin method");
            Console.WriteLine("InnerRunning: Sleeping For 5 seconds");
            Console.WriteLine("5 " + Thread.CurrentThread.ManagedThreadId);
            await Task.Run(() => Thread.Sleep(5000));
            Console.WriteLine("6 " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("InnerRunning: Wake up and exit");
        }
