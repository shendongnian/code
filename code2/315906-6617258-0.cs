    DateTime _lastChangeTime;
    ManualResetEvent _exitEvent; // set this event to exit thread.
    private void Watcher_Change(...)
    {
        _lastChangeTime = DateTime.UtcNow;
        Thread.MemoryBarrier();
    }
    private void ThreadProc()
    {
        while (_exitEvent.Wait(1000)) // every second
        {
            Thread.MemoryBarrier();
            if (DateTime.UtcNow.Subtract(lastChangeTime) > [some reasonable time])
            {
                // shit happens...
            }
        }
    }
