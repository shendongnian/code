cs
[Fact]
public async Task Repro()
{
    var db = new MongoDbContext("mongodb://localhost:27017", "myDb");
    var document = new DummyDocument { Test = "abc", Id = Guid.Parse("69695d2c-90e7-4a4c-b478-6c8fb2a1dc5c") };
    await db.GetCollection<DummyDocument>().InsertOneAsync(document);
    var filter = Builders<DummyDocument>.Filter.Eq("Id", document.Id);
    var update = Builders<DummyDocument>.Update.Set("Test", "bla");
    await db.GetCollection<DummyDocument>().UpdateOneAsync(filter, update);
}
**UPDATE:**
Based on OP comment, to send an entire object instead of updating specific properties, try [`ReplaceOneAsync`][2]:
cs
⋮
var filter = Builders<DummyDocument>.Filter.Eq("Id", document.Id);
await db.GetCollection<DummyDocument>().ReplaceOneAsync(filter, new DummyDocument { Test = "bla" }, new UpdateOptions { IsUpsert = true });
  [1]: http://mongodb.github.io/mongo-csharp-%20driver/2.9/getting_started/quick_tour/#updating-documents
  [2]: http://mongodb.github.io/mongo-csharp-driver/2.9/apidocs/html/Overload_MongoDB_Driver_IMongoCollection_1_ReplaceOneAsync.htm
