    MyObject cachedObject = Cache[CACHE_KEY] as MyObject;
    // or MyObject cachedObject = (MyObject) Cache[CACHE_KEY]; if you know it is of type MyObject
    if(cachedObject == null) 
    {     
        cachedObject = ... // generate the cached object
        Cache.Insert(CACHE_KEY, cachedObject, ...);
    } 
    // use cachedObject
