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
        SpinLock();
        queue.Push(item);
        if (queue.Count() == 1)
        {
            semaphor.Increase();
        }
        UnSpinLock();
    }
    Item RemoveItem()
    {
        SpinLock();
        if (queue.Count() == 0)
        {
            UnSpinLock();
            semaphore.Decrease();
            return RemoveItem();
        }
        return queue.Pop();
        UnSpinLock();
    }
