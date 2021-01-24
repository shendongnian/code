// Methods used in various places
internal static IMongoCollection<T> GetCollection<T>(string collectionName)
{
  return db.GetCollection<T>(collectionName);
}
// Your mongo entity CollectionTypeEntit
public class CollectionTypeEntity
{
    public const string COLLECTION_NAME = @"collectionName";
    [BsonId]
    public ObjectId ID { get; set; }
    public int propertyValue{ get; set; }
    
}
// Used in program to delete all records that match condition
GetCollection<CollectionTypeEntity>("CollectionName").DeleteMany(_ => _.propertyValue == true);
Note: db is instance of IMongoDatabase
