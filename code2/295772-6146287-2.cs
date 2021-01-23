    public class FooService
    {
       private static ReaderWriterLockSlim _lock;
       private static readonly object SyncLock = new object();
    
       private static ReaderWriterLockSlim Lock
       {
          get
          {
             if (_lock == null)
    	     {
    	       lock(SyncLock)
    	       {
    	          if (_lock == null)
    	             _lock = new ReaderWriterLockSlim();
    	       }
    	     } 
    	
             return _lock;
          }
       }
    
       public ReadOnlyCollection<Foo> RefreshFooCache(Foo parentFoo)
       {
    	   // Get the parent and everything below.
       	   var parentFooIncludingBelow = repo.FindFoosIncludingBelow(parentFoo.UniqueUri).ToList().AsReadOnly();
    
           try
           {
    	      Lock.EnterWriteLock();
    	
    	      // Remove the cache
    	     _cache.Remove(parentFoo.Id.ToString());
    
    	     // Add the cache.
    	     _cache.Add(parentFoo.Id.ToString(), parentFooIncludingBelow);
           }
           finally
           {
              Lock.ExitWriteLock();
           }
        	   
     	   return parentFooIncludingBelow;
       }
    
       public ReadOnlyCollection<Foo> FindFoo(string uniqueUri)
       {
          var parentIdForFoo = uniqueUri.GetParentId();
          ReadOnlyCollection<Foo> results;
          
          try
          {
             Lock.EnterReadLock();
             var cachedFoo = _cache.Get(parentIdForFoo);
             if (cachedFoo != null)
                results = cachedFoo.FindFoosUnderneath(uniqueUri).ToList().AsReadOnly();
          }
          finally
          {
             Lock.ExitReadLock();
          }
          if (results == null)
             results = RefreshFooCache(parentFoo).FindFoosUnderneath(uniqueUri).ToList().AsReadOnly();
          }
          
          return results;
       }
    }
