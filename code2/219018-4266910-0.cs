      private object syncObject = new object();
    
      private void threadMethod()
      {
       bool tryToRun = true;
       while(tryToRun)
       {
        if(Monitor.TryEnter(syncObject))
        {
         tryToRun = false;
         
         // do work - a lot of code here
         
         Monitor.Exit(syncObject);
        }
        else
        {
         Thread.Sleep(2000); // Possibly knock this up the how long you expect the lock to be held for.
        }
       }
      }
