csharp
interface IEntity<TId>
{
    TId GetId();
}
class Foo : IEntity<string>
{
    private string id;
    public Foo(string id)
    {
        this.id = id;
    }
    public string GetId()
    {
        return id;
    }
}
class Repository<TEntity, TId> where TEntity : IEntity<TId>
{
    private Dictionary<TId, TEntity> entities = new Dictionary<TId, TEntity>();
    public void Add(TEntity entity)
    {
        entities.Add(entity.GetId(), entity);
    }
    public TEntity Get(TId id)
    {
        return entities[id];
    }
}
