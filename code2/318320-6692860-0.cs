    //put an event handler on the collection
    public void CollectionChanged<T>(System.Collections.Specialized.NotifyCollectionChangedEventHandler eventHandler) where T : class
    {
         LocalDbContext.Set<T>().Local.CollectionChanged += eventHandler;
    }
