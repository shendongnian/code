    public void StopTimer()
    {
        dispatcherTimer.Stop();
        IsTimerStopped = true;
        if (Stopped != null)
        {
           //call event handler
            Stopped(this, new EventArgs());
        }
    }
