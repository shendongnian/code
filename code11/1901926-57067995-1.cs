csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace StackOverflow
{
    public class Program
    {
        public class Data
        {
            [BsonId]
            public ObjectId op_id { get; set; }
            public string op_box { get; set; }
            public string office { get; set; }
        }
        private static void Main(string[] args)
        {
            var collection = new MongoClient("mongodb://localhost:27017")
                                 .GetDatabase("Example")
                                 .GetCollection<Data>("Data");
            var id = ObjectId.GenerateNewId();
            //use ReplaceOne when you are inserting or updating whole documents
            collection.ReplaceOne(
                d => d.op_id == id,
                new Data()
                {
                    op_id = id,
                    op_box = "box",
                    office = "office"
                },
                new UpdateOptions
                {
                    IsUpsert = true
                });
            //use UpdateOne when you need to update only a few properties/fields
            collection.UpdateOne(
                d => d.op_id == id,
                Builders<Data>.Update.Set(d => d.office, "updated office"));
        }
    }
}
i've written a [library](https://github.com/dj-nitehawk/MongoDB.Entities) that simplifies much of this. check it out if you are able to use .net core framework. with it you can simply do `object.Save()` and it'll take care of upserting.
