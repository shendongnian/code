    class AsyncTests
    {
        public async Task StartAsync()
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} - Thread:{Thread.CurrentThread.ManagedThreadId} - starting whole process, calling await DoWork1Async()");
            await Task.WhenAll(DoWork1Async(), DoWork2Async());
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} - Thread:{Thread.CurrentThread.ManagedThreadId} - finished awaiting DoWork1Async and DoWork2Async");
        }
        public async Task DoWork1Async()
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} - Thread:{Thread.CurrentThread.ManagedThreadId} - starting DoWork1Async");
            await Sleep();
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} - Thread:{Thread.CurrentThread.ManagedThreadId} - finished DoWork1Async");
        }
        public async Task DoWork2Async()
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} - Thread:{Thread.CurrentThread.ManagedThreadId} - starting DoWork2Async");
            await Sleep();
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} - Thread:{Thread.CurrentThread.ManagedThreadId} - finished DoWork2Async");
        }        
        public async Task Sleep()
        {
            await Task.Delay(2000);
        }
    }
