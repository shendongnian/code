     //true makes the thread start as "running", false makes it wait on _event.Set()
      ManualResetEvent _event = new ManualResetEvent(true); 
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
