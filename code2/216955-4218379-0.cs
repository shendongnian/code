    [Conditional(#XNA),
     Conditional(#WINDOWS_PHONE)]
    public void DoSomeWork()
    {
        var x = null;
        x = DoSomeXNAWork();
        x = DoSomeWP7Work();
        if (x != null)
        {
            ...
        }
    }
    [Conditional(#XNA)]
    private ?? DoSomeXNAWork()
    {
        return ??;
    }
    [Conditional(#WINDOWS_PHONE)]
    private ?? DoSomeWP7Work()
    {
        return ??;
    }
