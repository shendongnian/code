    public static class MongoQueryableExtensions
    {
        public static BsonDocument GetMongoQuery<T>(this IQueryable<T> query)
        {
            if(query == null) throw new ArgumentNullException("query");
            Assembly fluentMongoAssembly = typeof(FluentMongo.Linq.MongoCollectionExtensions).Assembly;
            Type mongoQueryableType = fluentMongoAssembly.GetType("FluentMongo.Linq.IMongoQueryable");
            BsonDocument queryDocument = null;
            if(mongoQueryableType.IsAssignableFrom(query.GetType()))
            {
                MethodInfo m = mongoQueryableType.GetMethod("GetQueryObject");
                object queryObject = m.Invoke(query, null);
                PropertyInfo queryProperty = fluentMongoAssembly.GetType("FluentMongo.Linq.MongoQueryObject").GetProperty("Query");
                queryDocument = (BsonDocument)queryProperty.GetValue(queryObject, null);
            }
            return queryDocument;
        }
    }
  
