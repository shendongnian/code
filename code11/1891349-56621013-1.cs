    // the following are class members
    bool _keepProcessingThreadAlive;
    Thread _processingThread;
    
    void ProcessingLoop() {
       while( _keepProcessingThreadAlive ) {
          _bufQueueEvent.WaitOne();  // thread will sleep until fresh data is available
          if( !_keepProcessingThreadAlive ) {
             break;  // check if thread is being waken for termination.
          }   
          int queueCount;
          lock( _bufQueue ) {
            queueCount = _bufQueue.Count;
          }
          for( int i = 0; i < queueCount; i++ ) {
             byte[] buffIn;
             lock( _bufQueue ) {
                // only lock during dequeue operation, this way the capture thread Will
                // be able to enqueue fresh data even if we are still doing DSP processing
                buffIn = _bufQueue.Dequeue();
             }
             byte[] buffOut = manipulate(buffIn);  // you are safe if this stage takes more time than normal, you will still get the incoming data   
          }
       }
    }
    
    void StartProcessingThread() {
      _keepProcessingThreadAlive = true;
      _processingThread = new Thread(new(ThreadStart(ProcessingLoop));
      _processingThread.Name = "ProcessingThread";
      _processingThread.IsBackground = true;
      _processingThread.Start();
    }
    
    void StopProcessingThread() {
       _keepProcessingThreadAlive = false;
       _bufQueueEvent.Set();  // wake up thread in case it is waiting for data
       _processingThread.Join();
    }
