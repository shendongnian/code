        try {
            cacheLock.EnterWriteLock();
            return "xyz";
        }
        finally {
            cacheLock.ExitWriteLock(); // Error is throwing here. 
        }
