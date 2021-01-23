    private object _lock = new object();
    private Timer _timer; // init somewhere else
    
    public void StopTheTimer()
    {
        lock (_lock) 
        {
            _timer.Stop();
        }
    }
    
    void elapsed(...)
    {
        lock (_lock)
        {
            // do whatever you do in the timer event
        }
    }
