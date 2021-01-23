    public static class GObjContextHelper
    {
      private static object _lock;
    
      public static GObjContext GetObjContext()
      {
        Trace.TraceInformation("_lock: " + _lock);
    
        lock (GetLockObject())
        {
          Trace.TraceInformation("exclusive section");
        }
        return null;
      }
      
      private static object GetLockObject()
      {
        if (_lock == null)
        {
          _lock = new object();
        }
        
        return _lock;
      }
      ....
    }
