    internal class MyObj
    {
        public long Id { get; set; }
        [BsonId]
        [BsonElement("_id")]
        public ObjectId MyId { get; set; }
        public string Name { get; set; }
        public List<Language> Languages { get; set; }
    }
    internal class Language
    {
        public string B { get; set; }
    }
    public static async Task<MyObj> Get(IMongoCollection<MyObj> collection, long id, string lang = null)
    {
        FilterDefinition<MyObj> filter = Builders<MyObj>.Filter.Eq(s => s.Id, id)
                                         & Builders<MyObj>.Filter.ElemMatch(l => l.Languages, s => s.B == lang);
        // excluding d.Languages by not including it.
        // it makes Languages = null.
        ProjectionDefinition<MyObj> projection = Builders<MyObj>.Projection
            .Include(d => d.Id)
            .Include(d => d.Name);
        FindOptions<MyObj> options = new FindOptions<MyObj> { Projection = projection };
        using (IAsyncCursor<MyObj> cursor = await collection.FindAsync(filter, options))
        {
            return cursor.SingleOrDefault();
        }
    }
...
    string connectionString = "mongodb://localhost:27017";
    var client = new MongoClient(connectionString);
    var db = client.GetDatabase("test");
    var myObjs = db.GetCollection<MyObj>("ItemWithLanguages");
    MyObj ret;
    Task.Run(async () => { ret = await Get(myObjs, 123, "cn"); }).ConfigureAwait(false).GetAwaiter()
        .GetResult();
