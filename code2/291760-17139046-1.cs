    public static T GetLocalOrAttach<T>(this DbSet<T> collection, Func<T, bool> searchLocalQuery, Func<T> getAttachItem) where T : class
    {
        T localEntity = collection.Local.FirstOrDefault(searchLocalQuery);
        if (localEntity == null)
        {
            localEntity = getAttachItem();
            collection.Attach(localEntity);
        }
        return localEntity;
    }
