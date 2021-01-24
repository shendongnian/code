    void SetupMemoryCheck()
    {
    
      Action<CancellationToken> BeCheckingTheMemory = ct =>
      {
    
        for (;;)
        {        
          if (ct.IsCancellationRequested) break;          
    
          FreeResources();
          Thread.Sleep(500);        
        }
      };
    
      HostingEnvironment.QueueBackgroundWorkItem(ct =>
      {
        new Task(() => BeCheckingTheMemory(ct), TaskCreationOptions.LongRunning).Start();
      });
    }
