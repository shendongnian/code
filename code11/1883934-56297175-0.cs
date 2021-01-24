    if (!ShardingEnabled) return;
            var database = collection.Database;
            var adminDb = Client.GetDatabase("admin");
            var configDb = Client.GetDatabase("config");
            //var dbs = Client.ListDatabaseNames().ToList();
            var databaseName = database.DatabaseNamespace.DatabaseName;
            var collectionName = collection.CollectionNamespace.CollectionName;
            var shardDbResult = adminDb.RunCommand<MongoDB.Bson.BsonDocument>(new MongoDB.Bson.BsonDocument() {
                
                { "enableSharding",$"{databaseName}" }
            });
            var shardScript = $"{{shardCollection: \"{databaseName}.{collectionName}\"}}";
            var commandDict = new Dictionary<string,object>();
            commandDict.Add("shardCollection", $"{databaseName}.{collectionName}");
            commandDict.Add("key",new Dictionary<string,object>(){{"_id","hashed"}});
            var bsonDocument = new MongoDB.Bson.BsonDocument(commandDict);
            var commandDoc = new BsonDocumentCommand<MongoDB.Bson.BsonDocument>(bsonDocument);
            var response = adminDb.RunCommand(commandDoc);
