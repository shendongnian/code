      System.Threading.ReaderWriterLockSlim criticalSection 
           = new System.Threading.ReaderWriterLockSlim(...);  
      ... converting from `IObservable<byte[]>` to `IObservable<XDocument>`  
      criticalSection.EnterReadLock();
      Call IObservable<XDocument>
      criticalSection.ExitReadLock();
      .... replacing IObservable<XDocument>
      criticalSection.EnterWriteLock();
      Call change IObservable<XDocument>
      criticalSection.ExitWriteLock();
