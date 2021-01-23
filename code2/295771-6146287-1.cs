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
         ReadOnlyCollection<Foo> results;
    	// Get the parent and everything below.
    	var parentFooIncludingBelow = _repo.FindFoosIncludingBelow(parentFoo.UniqueUri).ToList();
    
    	Lock.EnterWriteLock();
    	
    	// Remove the cache
    	_cache.Remove(parentFoo.Id.ToString());
    
    	// Add the cache.
    	_cache.Add(parentFoo.Id.ToString(), parentFooIncludingBelow );
        results = parentFooIncludingBelow.AsReadOnly();
    
    	Lock.ExitWriteLock();
    
    	return results;
       }
    
       public ReadOnlyCollection<Foo> FindFoo(string uniqueUri)
       {
          var parentIdForFoo = uniqueUri.GetParentId();
          List<Foo> results = null;
          
          Lock.EnterReadLock();
          var cachedFoo = _cache.Get(parentIdForFoo);
          if (cachedFoo != null)
             results = cachedFoo.FindFoosUnderneath(uniqueUri).AsReadOnly();
          Lock.ExitReadLock();
          
          if (results == null)
          {
             results = RefreshFooCache(parentFoo).FindFoosUnderneath(uniqueUri).ToList();
          }
          
          return results.AsReadOnly();
       }
    }
