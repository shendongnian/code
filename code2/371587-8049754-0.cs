    private Dictionary<int, Queue<Data>> mPortQueues = new Dictionary<int, Queue<Data>>();
    
    public void ReceiveData(int portNumber, Data data)
    {
        Queue<Data> queue;
    
        // See if we have a queue
        if (!mPortQueues.TryGetValue(portNumber, out queue))
        {
            // No queue for this port, so create and cache
            queue = new Queue<Data>();
    
            mPortQueues.Add(portNumber, queue);
        }
    
        // Queue the data
        queue.Enqueue(data);
    }
