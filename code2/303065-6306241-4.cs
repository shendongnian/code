    private ManualResetEvent _stopped = new ManualResetEvent(false);
    public void SomeFunction()
    {
         Stop();
         _stopped.WaitOne();
         Start();
    }
    private void Stop()
    {
        try
        {
             // Your code that does something to stop
        }
        finally
        {
             _stopped.Set();  // This signals the event
        }
    }
    private void Start()
    {
        _stopped.Reset();
        
        // Your other start code here
    }
