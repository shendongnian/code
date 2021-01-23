    // producer thread
    var refs = GetReferencesFromDB(); // ~5000 Datarow returned
    foreach(var ref in refs)
    {
        lock(queue)
        {   
           queue.Enqueue(ref);
           event.Set();
        }
            
        // if the queue is limited, test if the queue is full and wait.
    }
    // consumer threads
    while(true)
    {
        value = null;
        lock(queue)
        {
           if(queue.Count > 0)
           {
               value = queue.Dequeue();
           }
           else
           {
               event.WaitOne(); // event to signal that an item was placed in the queue.
           }
        }
        
        if(value != null) 
           // process value
    }
