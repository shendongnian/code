    private void Search() 
    { 
        const int CPUs = 2; 
        var done = new CountdownEvent(1);
    
        // Configure and launch threads using ThreadPool: 
        for (int i = 0; i < CPUs; i++) 
        { 
            done.AddCount();
            var f = new Indexer(Paths[i], doneEvents[i]); 
            ThreadPool.QueueUserWorkItem(
              (state) =>
              {
                try
                {
                  f.WaitCallBack(state);
                }
                finally
                {
                  done.Signal();
                }
              }, i); 
        } 
     
        // Wait for all threads in pool  
        done.Signal();
        done.Wait();
        Debug.WriteLine("Search completed!"); 
    } 
