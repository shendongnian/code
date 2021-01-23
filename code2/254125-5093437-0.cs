    public T Get()
    {
        lock (readerLock)
        {
            lock (poolLock)
            {
                //if no more left wait for one to get Pushed
                while (stack.Count < 1)
                    Monitor.Wait(poolLock);
                return stack.Pop();
            }
        }
    }
