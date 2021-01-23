    ...
    private int _ActiveThreads;
    public PCQueue(int workerCount)
    {
        _ActiveThreads = workerCount;
        _workers = new Thread[workerCount];
        // Create and start a separate thread for each worker
        for (int i = 0; i < workerCount; i++)
        {
            (_workers[i] = new Thread(Consume)).Start();
        }
    }
    void Consume()
    {
        while (true) // Keep consuming until
        { // told otherwise.
            string item;
            lock (locker)
            {
                while (_itemQ.Count == 0) Monitor.Wait(locker);
                item = _itemQ.Dequeue();
            }
            if (item == null)  // This signals our exit.
            {
                if (Interlocked.Decrement(ref _ActiveThreads) == 0)
                {
                    OnCompleted(EventArgs.Empty);
                }
                return;
            }
            DoSomething(item); // Execute item.
            OnItemProcessed();
        }
    }
    public event EventHandler ItemProcessed;
    protected void OnItemProcessed()
    {
        var handler = ItemProcessed;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
    ...
