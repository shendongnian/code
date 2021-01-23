    private static readonly ManualResetEvent ev = new ManualResetEvent();
    private static void Main()
    {
        ev.WaitOne()
    }
    private static void SomeOtherThread()
    {
        Thread.Sleep(1000);
        ev.Set();
    }
