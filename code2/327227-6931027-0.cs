    public class LockManager
    {
      public bool TryEnterIndividualLock(object value)
      {
        Lock();
        try
        {
          var myLock = FindLock(value);
          if (myLock != null)
          {
            return myLock.TryLock();
          }
          return false;
        }
        finally
        {
          Unlock();
        }
      }  
    }
