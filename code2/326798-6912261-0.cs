    for (int i = 0; i < 3000000; i++)
    {
       MongoServer server = MongoServer.Create("mongodb://localhost:27020");
       MongoDatabase database = server.GetDatabase("mpower_read");
       MongoCollection<Result> resultCollection = 
                                  database.GetCollection<Result>("results");
       resultCollection.Insert(new Result()
       {
         _id = ObjectId.GenerateNewId(),
         Content = i.ToString(),
         Location = i,
         Timestamp = DateTime.Now
       });
    }
