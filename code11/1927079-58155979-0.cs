csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace StackOverflow
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var content = File.ReadAllText("E:\\Downloads\\cars.txt"); //https://mongoplayground.net/p/LY0W7vjDuvp
            var docs = BsonSerializer.Deserialize<BsonArray>(content).Select(p => p.AsBsonDocument);
            var collection = new MongoClient("mongodb://localhost")
                                    .GetDatabase("test")
                                    .GetCollection<BsonDocument>("Cars");
            await collection.InsertManyAsync(docs);
        }
    }
}
