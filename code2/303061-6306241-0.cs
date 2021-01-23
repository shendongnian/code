    private AutoResetEvent _stopped = new AutoResetEvent(false);
    public void SomeFunction()
    {
         Stop();
         _stopped.WaitOne();
         Start();
    }
