    try
    {
        object myLock = new object();
        lock(myLock)
        {
            object otherLock = null;
            while(otherLock != myLock)
            {
               otherLock = lockDictionary.GetOrAdd(key, myLock);
               if (otherLock != myLock)
               {
                   // Another thread has a lock in the dictionary
                   if (Monitor.TryEnter(otherLock, timeoutMs))
                   {
                       // Another thread still has a lock after a timeout
                       failure();
                       return;
                   }
                   else
                   {
                       Monitor.Exit(otherLock);
                   }
               }
            }
            // We've successfully added myLock to the dictionary
            try
            {
               // Do our stuff
               success();
            }
            finally
            {
                lockDictionary.Remove(key);
            }
        }
    }
