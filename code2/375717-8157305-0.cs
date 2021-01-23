    void Consume()
    {
        while (true)
        {
            string item;
            lock (locker)
            {
                while (_itemQ.Count == 0) Monitor.Wait(locker);
                item = _itemQ.Dequeue();
            }
            if (item == null)
            {
                // activeThreads is set to the number of workers in the constructor.
                if (Interlocked.Decrement(ref activeThreads) == 0)
                {
                  // Take a snapshot of the event so that a null check + invocation is safe.
                  // This works because delegates are immutable.
                  var copy = TaskCompleted;
                  if (copy != null)
                  {
                    copy(this, new EventArgs());
                  }
                }
                return;
            }
            DoSomething(item); // Execute item.
        }
    }
