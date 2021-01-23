    const int MillisecondsToWait = 5000;
    System.Threading.Timer timer = new System.Threading.Timer(TimerCallback);
    
    public void MethodA()
    {
        ResetTimer();
        // Do whatever.
    }
    
    public void MethodB()
    {
        // Do whatever.
    }
    
    void ResetTimer()
    {
        timer.Change(MillisecondsToWait, System.Threading.Timeout.Infinite);
    }
    
    void TimerCallback(object state)
    {
        MethodB();
    }
