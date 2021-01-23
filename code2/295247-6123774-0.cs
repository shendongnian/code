    var server = MongoServer.Create("mongodb://localhost:27017");
    var db = server.GetDatabase("mydb");
    var col = db.GetCollection("col");
    
    var query = Query.And(Query.EQ("x", 3), Query.EQ("y", "abc"));
    var resultsCursor = col.Find(query).SetSortOrder("x");
    var results = resultsCursor.ToList();
