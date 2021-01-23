    static object DoSomeBlockingOperation(object args)
    {
        // block for 5 minutes
        Thread.Sleep(5 * 60 * 1000);
        return args;
    }
    static void ProcessTheResult(object result)
    {
        Console.WriteLine(result);
    }
    static void CalculateAndProcess(object args)
    {
        // let's calculate! (synchronously)
        object result = DoSomeBlockingOperation(args);
        // let's process!
        ProcessTheResult(result);
    }
