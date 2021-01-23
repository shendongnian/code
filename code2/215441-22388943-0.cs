    Create a new Dictionary object (let's call it AllCache)
    For Each per-processor segment in the cache (one Dictionary object per processor)
    {
        Lock the segment/Dictionary (using lock construct)
        Iterate through the segment/Dictionary and add each name/value pair one-by-one
           to the AllCache Dictionary (using references to the original MemoryCacheKey
           and MemoryCacheEntry objects)
    }
    Create and return an enumerator on the AllCache Dictionary
