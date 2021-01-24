    var sourceCollectionName = "source";
    var targetCollectionName = "target";
    var sourceCollection = Db.GetCollection<BsonDocument>(sourceCollectionName);
    List<BsonDocument> sourceCollectionIndexes = await (await sourceCollection.Indexes.ListAsync()).ToListAsync();
    foreach(var indexDef in sourceCollectionIndexes)
    {
        indexDef.Remove("ns");
    }
    await Db.RunCommandAsync<BsonDocument>(new BsonDocument()
    {
        { "createIndexes", targetCollectionName },
        {
            "indexes", new BsonArray(sourceCollectionIndexes)
        }
    });
