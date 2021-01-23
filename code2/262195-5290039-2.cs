    CountdownEventlatch = new CountdownEvent(taskGroups.Count());
    
    for (int i = 0; i < taskGroups.Count(); i++) {
        ThreadStart t = delegate 
        { 
            RunThread(taskGroups[i]); 
            latch.Signal();
        };
        new Thread(t).Start();
    }
    
    latch.Wait();
