    public ReadOnlyCollection<Foo> RefreshFooCache(Foo parentFoo)
       {
         ReadOnlyCollection<Foo> results;
    
    
        try {
        Lock.EnterUpgradableReaderLock();
        // Get the parent and everything below.
        var parentFooIncludingBelow = _repo.FindFoosIncludingBelow(parentFoo.UniqueUri).ToList();
        Lock.EnterWriteLock();
    
    // Recheck your cache: it may have already been updated by a previous thread before we gained exclusive lock
    if (_cache.Get(parentFoo.Id.ToString()) != null) {
      return parentFoo.FindFoosUnderneath(uniqueUri).AsReadOnly();
    }
    
        // Remove the cache
        _cache.Remove(parentFoo.Id.ToString());
    
        // Add the cache.
        _cache.Add(parentFoo.Id.ToString(), parentFooIncludingBelow );
       
    
       } finally {
    if (Lock.IsWriteLockHeld) {
            Lock.ExitWriteLock();
    }
        Lock.ExitUpgradableReaderLock();
       }
        results = parentFooIncludingBelow.AsReadOnly();
        return results;
       }
