    private static ReaderWriterLockSlim readerLock = new ReaderWriterLockSlim();
    void SomeOperationA()
    {
        try
        {  
            readerLock.EnterReadLock(); 
            // Segment1: 
            // ... only executes if no threads are executing in Segment2 ... 
        }    
        finally
        {
            readerLock.ExitReadLock();
        }
    }
    void SomeOperationB()
    {
        try
        {  
            readerLock.EnterWriteLock(); 
            // Prevents multiple Segment2 from serializing, and prevents all Segment1 threads...
        }    
        finally
        {
            readerLock.ExitWriteLock();
        }
    }
