    List<IMongoQuery> build = new List<IMongoQuery>();
    build.Add(Query.ElemMatch("Relationships", Query.EQ("RelationshipType", "Person")));
    var searchQuery =  String.Format("/.*{0}.*/", "sta");
    build.Add(Query.ElemMatch("Relationships", Query.Or(Query.EQ("Attributes.FirstName", new BsonRegularExpression(searchQuery)), Query.EQ("Attributes.LastName", new BsonRegularExpression(searchQuery)))));
    var _main = Query.And(build.ToArray());
    var DB = MongoDatabase.Create("UrlToMongoDB");
    DB.GetCollection<ObjectToQuery>("nameOfCollectionInMongoDB").FindAs<ObjectToQuery>(_main).ToList();
`
