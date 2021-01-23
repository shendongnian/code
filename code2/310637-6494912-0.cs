    public static MongoCollection<T> GetCollection<T>(string collectionName = null)
    {
        if (string.IsNullOrWhiteSpace(collectionName))
        {
            Type g = typeof (T);
            collectionName = g.Name;
        }
        return MongoServer.Create(Config.MongoConnectionString).GetDatabase(Config.Database).GetCollection<T>(collectionName);
    }
