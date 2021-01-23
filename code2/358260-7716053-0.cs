        bool _isPaused;
    
    void DoWork()
    {
            while (true)
            {
                lock (_locker)
                {
                    while (_isPaused) Monitor.Wait(_locker);
    
                    // your worker code here
    
                }
          
            }
    }
            // 
    void UnPause()
    {
            lock (_locker)
            {
                _isPaused=false;
                Monitor.PulseAll(_locker);
            }
    }
