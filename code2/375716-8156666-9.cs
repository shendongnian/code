    void Consume()
    {
        while (true) // Keep consuming until
        { // told otherwise.
            string item;
            lock (locker)
            {
                while (_itemQ.Count == 0) Monitor.Wait(locker);
                item = _itemQ.Peek();
                if (item != null) _itemQ.Dequeue();
                else Monitor.PulseAll(); // if the head of the queue is null then make sure all other threads are also woken up so they can quit
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
