public CacheController()
    {
        this._memoryCache = new // whatever memory cache you choose;
    }
You can even better inject it somewhere using dependency injection. The place depends on application type. 
But best of all, try to have only once cache. Each time you create one you lose the previous, so you will either try the singleton pattern, or inject using a single instance configuration and let the DI container handle the rest. 
