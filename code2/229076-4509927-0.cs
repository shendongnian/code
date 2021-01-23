    private bool _pause = false;
    private object _threadLock = new object();
    private void RunThread()
    {
        while (true)
        {
            if (_pause)
            {
                lock (_threadLock)
                {
                    Monitor.Wait(_threadLock);
                }
            }
            // Do work
        }
    }
    private void PauseThread()
    {
        _pause = true;
    }
    private void ResumeThread()
    {
        _pause = false;
        lock (_threadLock)
        {
            Monitor.Pulse(_threadLock);
        }
    }
