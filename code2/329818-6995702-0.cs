    #if DEBUG
    while (!System.Diagnostics.Debugger.IsAttached)
    {
        Thread.Sleep(1000);
    }
    System.Diagnostics.Debugger.Break();
    #endif
