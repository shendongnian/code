    var _mongoServer = MongoServer.Create(
         MongoUrl.Create("mongodb://admin(admin):1@orsich-pc:27020"));
    var database = _mongoServer.GetDatabase("StackoverflowExamples");
    var collection = database.GetCollection("guids");
    var guid = Guid.NewGuid();
    var item = new Item()
       {
         Id = ObjectId.GenerateNewId().ToString(),
         GuidField = guid
       };
    collection.Insert(item);
    var itemFromDb = collection.FindOneAs<Item>(Query.EQ("GuidField", guid));
    
