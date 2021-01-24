csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Test
{
    [BsonIgnoreExtraElements]
    public class Employee
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("id")]
        [BsonRepresentation(BsonType.String)] // to avoid manual conversion
        public int CustomerId { get; set; }
        [BsonElement("name")]
        public string CustomerName { get; set; }
    }
}
**DB Context**
csharp
using MongoDB.Driver;
using System.Linq;
namespace Test.DbContext
{
    public class MongoDbContext
    {
        private readonly IMongoClient _mongoDbClient = null;
        private readonly IMongoDatabase _mongoDb = null;
        public MongoDbContext()
        {
            _mongoDbClient = new MongoClient("mongodb://localhost");
            _mongoDb = _mongoDbClient.GetDatabase("test");
        }
        public IAggregateFluent<TDocument> Aggregate<TDocument>() =>
            _mongoDb.GetCollection<TDocument>(nameof(TDocument)).Aggregate();
    }
}
**Repository**
csharp
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Test.DbContext;
namespace Test.Repositories
{
    public class CustomerRepository
    {
        private static readonly MongoDbContext _dbContext = new MongoDbContext();
        public List<dynamic> GetSpecificData()
        {
            var result = _dbContext.Aggregate<Employee>()
                             .Match(e => e.CustomerId == 11)
                             .Group(e => e.Type, g => new { Key = g.Key, Count = g.Count(), Average = g.Average(e => e.CustomerId) })
                             .ToList();
            return result.Cast<dynamic>().ToList();
        }
    }
}
i'd also recommend you to not cast anonymous type to dynamic. so, create and use another class (for group result) to retain type-safety.
i can also recommend for you to have a look at a [library](https://github.com/dj-nitehawk/MongoDB.Entities) i've written which eradicates the need to write your own dbContext.
then have a look at [this](https://github.com/dj-nitehawk/MongoWebApiStarter) starter template project to see it in use.
