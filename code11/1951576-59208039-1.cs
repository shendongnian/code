    var client = new MongoClient(connectionString);
    var db = client.GetDatabase("STRDB");
    var mongoCollection = db.GetCollection<BsonDocument>(collection);
    var documents = mongoCollection.AsQueryable();
    return Ok(documents.ToList().ConvertAll(BsonTypeMapper.MapToDotNetValue));
