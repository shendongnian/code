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
  [1]: http://mongodb.github.io/mongo-csharp-%20driver/2.9/getting_started/quick_tour/#updating-documents
