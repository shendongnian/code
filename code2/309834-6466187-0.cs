    static void Throws()
    {
        Console.WriteLine("Thread: {0}", Thread.CurrentThread.ManagedThreadId);
    
        throw new ApplicationException("Test 1");
    }
    
    [OneWay]
    static void ThrowsButIsIgnored()
    {
        Console.WriteLine("Thread: {0}", Thread.CurrentThread.ManagedThreadId);
    
        throw new ApplicationException("Test 2");
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Main: {0}", Thread.CurrentThread.ManagedThreadId);
    
        var willIgnoreThrow = new Action(ThrowsButIsIgnored);
        var result1 = willIgnoreThrow.BeginInvoke(null, null);
    
        Console.ReadLine();
        willIgnoreThrow.EndInvoke(result1);
    
        Console.WriteLine("===========================");
    
        var willNotIgnoreThrow = new Action(Throws);
        var result2 = willNotIgnoreThrow.BeginInvoke(null, null);
    
        Console.ReadLine();
        willNotIgnoreThrow.EndInvoke(result2);
    }
