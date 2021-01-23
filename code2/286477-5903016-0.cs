    void Main()
    {
        new Timer(Callback, null, 0, 1000);
        Thread.Sleep(5000);
        Debug.WriteLine("collecting");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Debug.WriteLine("collected");
        Thread.Sleep(5000);
    }
    
    static void Callback(object state)
    {
        Debug.WriteLine("callback");
    }
