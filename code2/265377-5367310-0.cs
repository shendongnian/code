    public static void RemoveEach<T>(this EntityCollection<T> collectionToEmpty)
        where T : class
    {
        if (!collectionToEmpty.IsLoaded) collectionToEmpty.Load();
        while (collectionToEmpty.Any()) collectionToEmpty.Remove(collectionToEmpty.First());
    }
