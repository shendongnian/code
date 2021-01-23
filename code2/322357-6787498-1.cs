    private void DoSomething()
    {
    #if DEBUG
        try
        {
    #endif
            //do something
    #if DEBUG
        }
        catch
        {
            Debugger.Break();
            throw;
        }
    #endif
    }
