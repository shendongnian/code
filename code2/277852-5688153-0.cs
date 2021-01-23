    // `workitem` is an object that contains the database modification request
    //
    // `queue` is a Queue<T> that can hold these workitem requests
    //
    //  `processing_lock` is an object use to provide a lock
    //      to indicate a thread is processing the queue
    // any number of threads can call this function, but only one
    //  will end up processing all the workitems.
    //
    // The other threads will simply drop the workitem in the queue
    //  and leave
    void threadpoolHandleDatabaseUpdateRequest(workitem)
    {
        // put the workitem on a queue
        Monitor.Enter(queue.SyncRoot);
        queue.Enqueue(workitem);
        Monitor.Exit(queue.SyncRoot);
        bool doProcessing;
        Monitor.TryEnter(processing_queue, doProcessing);
        if (!doProcessing) {
            // another thread has the processing lock, it'll
            //  handle the workitem
            return;
        }
        
        for (;;) {
            
            Monitor.Enter(queue.SyncRoot);
            if (queue.Count() == 0) {
                // done processing the queue
                
                // release locks in an order that ensures 
                // a workitem won't get stranded on the queue
                
                Monitor.Exit(processing_queue);
                Monitor.Exit(queue.SyncRoot);
                break;
            }
            
            workitem = queue.Dequeue();
            Monitor.Exit(queue.SyncRoot);
            // this will get the database mutex, do the update and release 
            //  the database mutex
            doDatabaseModification(workitem); 
        }
    }
