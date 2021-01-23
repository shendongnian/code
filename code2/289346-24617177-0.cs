    private void MultiLock(object[] locks, WaitCallback pFunc, int index = 0)
    {
        if (index < locks.Count())
        {
            lock (locks[index])
            {
                MultiLock(locks, pFunc, index + 1);
            }
        }
        else
        {
            ThreadPool.QueueUserWorkItem(pFunc);
        }
    }
