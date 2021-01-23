    // Pseudocode
    static DelayedManualEvent delayedEvent = new DelayedManualEvent();
    static TimeSpan t1, t2, maxTimeout;
    
    public static void DoThis()
    {
        if(!delayedEvent.WaitOne(maxTimeout))
            return;
        DoStuff();
        delayedEvent.DelayedSet(t1);
    }
    
    public static void DoThat()
    {
        if(!delayedEvent.WaitOne(maxTimeout))
            return;
        DoOtherStuff();
        delayedEvent.DelayedSet(t2);
    }
