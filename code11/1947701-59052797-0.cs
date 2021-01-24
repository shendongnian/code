        public async Task<List<BsonDocument>> DataSelectAsync(string query, string collection)
        {
            IMongoCollection<BsonDocument> coll = db.GetCollection<BsonDocument>(collection)
New code:
        public async Task<List<T>> DataSelectAsync<T>(string query, string collection, T classData) where T : class
        {
            IMongoCollection<T> coll = db.GetCollection<T>(collection);
The generic declaration of the collection type sends the results through the class map and bypasses the Bson deserialization. 
