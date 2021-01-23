    var names = new List<string>();
    names.Add("Jones");
    names.Add("Smith");
    var query = Query.In("surname", BsonArray.Create(names));
    collection.FindAs<BsonDocument>(query);
