    CountdownEvent = new CountdownEvent(taskGroups.Count());
    
    for (int i = 0; i < taskGroups.Count(); i++) 
    {
        int item = i; // copy i locally
        ThreadStart t = delegate 
        { 
            RunThread(taskGroups[item]); 
            latch.Signal();
        };
        new Thread(t).Start();
    }
    
    latch.Wait();
