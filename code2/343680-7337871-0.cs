    MongoServer server = MongoServer.Create(host);
    MongoDatabase db = server.GetDatabase(databaseName);
    MongoCollection Collection = db.GetCollection("collection");
    var query = new QueryDocument("MyArray.0", searchValue);
    var testCollection = matchCollection.FindAs<TestClass>(query);
