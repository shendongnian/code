c#
public interface IEntity
{
   string id { get; set; }
}
Then in the repository class (according the method you posted, I assume it is a generic repository class of TEntity), add generic constraint on `TEntity` as follows:
c#
public class MyRepository<TEntity> where TEntity : IEntity
{
    // collection should be IMongoCollection<TEntity> 
    private IMongoCollection<TEntity> collection; // initialized elsewhere
    
    public async Task<string> Update(string id, TEntity user)
    {
        await collection.ReplaceOneAsync(x => x.id == id, user);
        return "";
    }
    // ...other members...
}
Since we included generic constraint `where TEntity : IEntity`, the compiler now knows that every `TEntity` has a `string id` property.
