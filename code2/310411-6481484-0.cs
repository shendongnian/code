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
