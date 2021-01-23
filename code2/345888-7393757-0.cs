    public class WriteLock : IDisposable
    {
       ReaderWriterLockSlim _rwlock;
       public WriteLock(ReaderWriterLockSlim rwlock ) 
       { 
          _rwlock = rwlock;
          _rwlock.EnterWriteLock(); 
       }
       public Dispose()
       {
          _rwlock.ExitWriteLock(); 
       }
    }
