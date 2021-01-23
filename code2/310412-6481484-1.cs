    AutoResetEVent _autoResetEvent = new AutoResetEvent(true);
    Semaphore _semaphore = new Semaphore(1, 1);
    private void Foo()
    {
        _autoResetEvent.WaitOne();
        try
        {
            //some code
            Console.WriteLine("Thread At Foo Entered {0}", Thread.CurrentThread.ManagedThreadId);
        }
        finaly
        {
            _autoResetEvent.Set();
        }
    }
    private void Bar()
    {
        _semaphore.WaitOne();
        try
        {
            //some code
            Console.WriteLine("Thread At Bar Entered {0}", Thread.CurrentThread.ManagedThreadId);
        }
        finaly
        {
            _semaphore.Release();
        }
    }
    void Main()
    {
        new Thread(Foo) { IsBackground = true }.Start();
        new Thread(Foo) { IsBackground = true }.Start();
        new Thread(Bar) { IsBackground = true }.Start();
        new Thread(Bar) { IsBackground = true }.Start();
    
        Thread.Sleep(2000);//give it some time to execute.
        Console.ReadLine();
    }
    
    //output is something like this:
    Thread At Foo Entered 11
    Thread At Foo Entered 12
    Thread At Far Entered 13
    Thread At Far Entered 14
