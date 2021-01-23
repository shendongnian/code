    /// Non-blocking lock (busy wait)
    void SpinLock()
    {
        While (CompareAndExchange(myIntegerLock, -1, 0) != 0)
        {
            // wait
        }
    }
    void UnSpinLock()
    {
        Exchange(myIntegerLock, 0);
    }
    void AddItem(item)
    {
        // Use CAS for synchronization
        SpinLock(); // Non-blocking lock (busy wait)
        queue.Push(item);
        // Unblock any blocked consumers
        if (queue.Count() == 1)
        {
            semaphore.Increase();
        }
        // End of CAS synchronization block
        UnSpinLock();
    }
    Item RemoveItem()
    {
        // Use CAS for synchronization
        SpinLock(); // Non-blocking lock (busy wait)
        // If empty then block
        if (queue.Count() == 0)
        {
            // End of CAS synchronization block
            UnSpinLock();
            // Block until queue is not empty
            semaphore.Decrease();
            // Try again (may fail again if there is more than one consumer)
            return RemoveItem();
        }
        result = queue.Pop();
        // End of CAS synchronization block
        UnSpinLock();
        return result;
    }
