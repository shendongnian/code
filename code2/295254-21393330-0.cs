        public QueryDocument GetQueryFromString(string jsonQuery)
        {
            return new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
        }
        
        public IEnumerable<T> QueryFromString<T>(string jsonQuery, string collectionName = null)
        {
            if (string.IsNullOrEmpty(collectionName))
                collectionName = this.CollectionName;
            var query = GetQueryFromString(jsonQuery);            
            var items = Database.GetCollection<T>(collectionName).Find(query);
            return items as IEnumerable<T>;
        }
        public IEnumerable<T> QueryFromObject<T>(object queryObject, string collectionName = null)
        {
            if (string.IsNullOrEmpty(collectionName))
                collectionName = this.CollectionName;
            var query = new QueryDocument(queryObject.ToBsonDocument());
            var items = Database.GetCollection<T>(collectionName).Find(query);
            return items as IEnumerable<T>;
        }
