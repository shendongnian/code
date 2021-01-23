    List<IMongoQuery> build = new List<IMongoQuery>();
    build.Add(Query.EQ("SomeProp", someValue));
    build.Add(Query.ElemMatch("SubArray", Query.EQ("prop.someprop", "someValue")));
    var searchQuery =  String.Format("/.*{0}.*/", "query");
    build.Add(Query.ElemMatch("SubArray2", Query.Or(Query.EQ("prop.prop1", new BsonRegularExpression(searchQuery)), Query.EQ("prop.prop2", new BsonRegularExpression(searchQuery)))));
    var _main = Query.And(build.ToArray());
    var DB = MongoDatabase.Create("UrlToMongoDB");
    DB.GetCollection<ObjectToQuery>("nameOfCollectionInMongoDB").FindAs<ObjectToQuery>(_main).ToList();
`
