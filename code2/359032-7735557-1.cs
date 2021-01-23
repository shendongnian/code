    private string ProcessText()
    {
        cacheLock.EnterWriteLock();
        try {
            return "xyz";
        }
        finally {
            cacheLock.ExitWriteLock(); // Error is throwing here. 
        }
    }
