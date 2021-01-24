csharp
// an empty marker interface
public interface IAggregateRoot{ }
// a common entity that has an `Id` property
public abstract class BaseEntity
{
    public virtual int Id { get; protected set; }
}
// the common Repo interface
public interface IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<int> CountAsync(ISpecification<T> spec);
}
And then make your specific repo service inherit the `IRepository<T>`. For example, your `IGateRepository` can be refactored as:
public class Gate: BaseEntity, IAggregateRoot
{
    // Add Gate props here
}
public interface IGateService : IAsyncRepository<Gate>
{
    // add more interface methods if you want
}
By this way, you can invoke the service with generic types inference:
await gateSvc.AddAsync(gate);
await fundedSvc.AddAsync(funded);
...  
