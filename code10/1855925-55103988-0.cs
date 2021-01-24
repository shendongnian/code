public interface IEntity<TKey> where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }
}
All entities should implement this interface and then you can have `IRepository` like this:
public interface IRepository<TEntity, in TKey> where TEntity : IEntity<TKey> where TKey : IEquatable<TKey>
{
    (...)
    Task<TEntity> GetByIdAsync(TKey id);
    void Insert(TEntity entity);
    (...)
}
