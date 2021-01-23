    ...
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
            if (item == null) 
            {
                OnCompleted(EventArgs.Empty);
                return; // This signals our exit.
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
            ItemProcessed(this, EventArgs.Empty);
        }
    }
    ...
