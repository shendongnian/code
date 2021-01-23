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
    
       public ConcurrentDictionary<string,Foo> RefreshFooCache(Foo parentFoo)
       {
    	// Get the parent and everything below.
    	var parentFooIncludingBelow = _repo.FindFoosIncludingBelow(parentFoo.UniqueUri).ToList();
    
    	// Create new cached dictionary.
    	var results = new ConcurrentDictionary<string, Foo>(parentFooIncludingBelow.ToDictionary(key => key.UniqueUri, value => value));
    
    	Lock.EnterWriteLock();
    	
    	// Remove the cache
    	_cache.Remove(parentFoo.Id.ToString());
    
    	// Add the dictionary cache.
    	_cache.Add(parentFoo.Id.ToString(), results);
    
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
             results = cachedFoo.Values.FindFoosUnderneath(uniqueUri).ToList();
          Lock.ExitReadLock();
          
          if (results == null)
          {
             var refreshedFoo = RefreshFooCache(parentFoo);
             Lock.EnterReadLock();
             results = refreshedData.Values.FindFoosUnderneath(uniqueUri).ToList();
             Lock.ExitReadLock();
          }
          
          return results.AsReadOnly();
       }
    }
