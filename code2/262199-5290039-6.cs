    CountdownEvent = new CountdownEvent(taskGroups.Count());
    
    for (int i = 0; i < taskGroups.Count(); i++) 
    {
        int item = i; // copy i locally
        Thread t = new Thread(()=>
        { 
            RunThread(taskGroups[item]); 
            latch.Signal();
        });
        t.IsBackground = true;
        t.Start();
    }
    
    latch.Wait();
