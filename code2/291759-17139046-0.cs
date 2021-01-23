    public static T AttachOrGetLocal<T>(this DbSet<T> collection, Func<T, bool> searchQuery, T addItem) where T : class
    {
        T existsResult = collection.Local.FirstOrDefault(searchQuery);
        if (existsResult == null)
        {
            collection.Attach(addItem);
            return addItem;
        }
        else
        {
            return existsResult;
        }
    }
