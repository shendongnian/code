    void SetupMemoryCheck()
    {
      Action<CancellationToken> BeCheckingTheMemory = ct =>
      {
        for(;;)
        {
          if (ct.IsCancellationRequested)
          {
            break;
          }
    
          CheckMemory_OptionallyReleaseOldHandles();
          Thread.Sleep(500);
        };
      };
      
      HostingEnvironment.QueueBackgroundWorkItem(ct =>
      {
        var tf = new TaskFactory(ct, TaskCreationOptions.LongRunning, TaskContinuationOptions.None, TaskScheduler.Current);
        tf.StartNew(() => BeCheckingTheMemory(ct));
      });
    }
