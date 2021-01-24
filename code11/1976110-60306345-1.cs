    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace Testing
    {
        class Program
        {
            static void Main(string[] args)
            {
                MongoClient client = new MongoClient("mongodb://localhost:27017/test");
                IMongoDatabase database = client.GetDatabase("test");
                IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Companies");
    
                string searchTerm = "CONST";
                string searchResult = FetchKeysBySearchTerm(collection, searchTerm).Result.ToJson();
                Console.WriteLine(searchResult);
            }
    
            public async static Task<List<BsonDocument>> FetchKeysBySearchTerm(IMongoCollection<BsonDocument> collection, string searchTerm)
            {
                string addFieldStage = @"{ $addFields: { deconstructed_aliases: { $objectToArray: ""$Aliases"" } } }";
                string unwindStage = @"{ $unwind: ""$deconstructed_aliases"" }";
                string projectStage = @"{ $project: { _id: 0, key: ""$deconstructed_aliases.v.Key"", fullName: ""$deconstructed_aliases.v.FullName"" } }";
    
                var aggregate = collection.Aggregate()
                                          .AppendStage<BsonDocument>(addFieldStage)
                                          .AppendStage<BsonDocument>(unwindStage)
                                          .Match(Builders<BsonDocument>.Filter.Regex("deconstructed_aliases.v.FullName", new BsonRegularExpression(searchTerm, "i")))
                                          .AppendStage<BsonDocument>(projectStage);
    
    
                List<BsonDocument> searchResults = await aggregate.ToListAsync();
                return searchResults;
            }
        }
    }
