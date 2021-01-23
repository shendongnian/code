    Mutex unlockMutex = new Mutex(false, "MyUniqueName");
    // Release access to unlock mutex
    try
    {
        unlockMutex.ReleaseMutex();
    }
    catch (ApplicationException ex)
    {
        Exception ex2 = ex.InnerException;
    }
