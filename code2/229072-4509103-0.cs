      ManualResetEvent _event = new ManualResetEvent(false);
      Thread _thread = new Thread(ThreadFunc);
    
      public void ThreadFunc(object state)
      {
          while (true)
          {
              _event.Wait();
    
              //do operations here
          }
      }
      _thread.Start();
      // to suspend thread.
      _event.Reset();
      //to resume thread
      _event.Set();
