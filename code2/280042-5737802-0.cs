    const int NumLocks = 100;
    List<object> LockObjects = new List<object>(NumLocks);
    
    // to initialize
    for (int i = 0; i < NumLocks; ++i)
    {
        LockObjects.Add(new object());
    }
    
    // and your loop
    for (int i = 0; i < NumLocks; ++i)
    {
        // if current thread needs lock[i] then
        lock(LockObjects[i])
        {
            // do whatever you need to do
            // and then release the lock
        }
    }
