    public CachedThingFactory([Named("ThePureThing")] IThingFactory wrapped)
    {
        this._wrapped = wrapped;
        _cachedThings = new Dictionary<int,Thing>();
    }
