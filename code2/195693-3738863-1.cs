    public class Cell
    {
      private ReaderWriterLockSlim m_LockObject = new ReaderWriterLockSlim();
    
      public object ReadMyState()
      {
        m_LockObject.EnterReadLock();
        try
        {
          // Return the data here.
        }
        finally
        {
          m_LockObject.ExitReadLock();
        }
      }
    
      public void ChangeMyState()
      {
        m_LockObject.EnterWriteLock();
        try
        {
          // Make your changes here.
        }
        finally
        {
          m_LockObject.ExitWriteLock();
        }
      }
    }
