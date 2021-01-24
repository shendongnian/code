csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Entity
        {
            [BsonId]
            public ObjectId Id { get; set; }
            public DateTime TimeStamp { get; set; }
        }
        public class Sample : Entity
        {
            public string Something { get; set; }
        }
        private static void Main(string[] args)
        {
            var collection = new MongoClient("mongodb://localhost:27017")
                                 .GetDatabase("Test")
                                 .GetCollection<Entity>("Samples");
            var sample = new Sample
            {
                Id = ObjectId.GenerateNewId(),
                Something = "something",
                TimeStamp = DateTime.UtcNow
            };
            collection.InsertOne(sample);
            var result = collection.AsQueryable()
                                   .Where(s =>
                                          s.TimeStamp >= DateTime.UtcNow.AddMinutes(-1) &&
                                          s.TimeStamp <= DateTime.UtcNow.AddMinutes(1))
                                   .ToArray();
        }
    }
}
