    static bool _stopPolling = false;
    static Thread _pollerThread;
    static object _oneTimeLocker = new object();
    private static CreatePollerThread()
    {
      if(_pollerThread == null)
      {
        lock(_oneTimeLocker)
        {
          if(_pollerThread == null) //double-check
          {
            _pollerThread = new Thread(
            new ThreadStart(() => 
            { 
              while(true && !_stopPolling)
              { 
                DoWork(); 
                Thread.Sleep(10000); 
              }
            }));  
            _pollerThread.Start();
          }
        }
      }
    }
