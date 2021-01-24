     public void InvokeWriteMethod(Delegate method, params object[] args)
     {
         readWriteLock.AcquireWriterLock(-1);
         try
         {
             method.DynamicInvoke(args);
         }
         finally
         {
             readWriteLock.ReleaseWriterLock();
         }
     }
