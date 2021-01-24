    public void WithReadLock(Action action)
    {
        var lockAcquired = false;
        try
        {
            try { }
            finally
            {
                _Lock.EnterReadLock();
                lockAcquired = true;
            }
            action();
        }
        finally
        {
            if (lockAcquired) _Lock.ExitReadLock();
        }
    }
