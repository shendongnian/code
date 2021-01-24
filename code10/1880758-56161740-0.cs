     var fromConnectionString = "mongodb://localhost:27017"; // if copy between same database then obviously you only need one connectionstring and one MongoClient
     var toConnectionString = "mongodb://localhost:27017";
     var sourceClient = new MongoClient(fromConnectionString);
     var copyFromDb = sourceClient.GetDatabase("CopyFromDatabaseName");
     var copyCollection = copyFromDb.GetCollection<BsonDocument>("FromCollectionName").AsQueryable(); // or use the c# class in the collection
     var targetClient = new MongoClient(toConnectionString);
     var targetMongoDb = targetClient.GetDatabase("CopyToDatabase");
     var targetCollection = targetMongoDb.GetCollection<BsonDocument>("ToCollectionName");
      
     targetCollection.InsertMany(copyCollection);
