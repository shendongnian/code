    public MongoCursor<T> GetAll<T>(QueryComplete query) where T : DataAccess {
        MongoServer server = MongoServer.Create(C.connectionString);
        MongoDatabase db = server.GetDatabase(C.database);
        MongoCollection<T> collection = db.GetCollection<T>(_collectionName);
        return collection.FindAs<T>(query);
    }
    List<ProgramE> ServerPrograms = p.GetAll<ProgramE>(query).ToList();
