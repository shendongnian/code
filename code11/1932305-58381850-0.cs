    public interface IEntity
    {
    }
    public interface IEntity<out T> : IEntity
    {
        T Id { get; }
    }
    public abstract class EntityBase<T> : IEntity<T>
    {
        public T Id { get; private set; }
    }
    public interface IRepository<TEntity> where TEntity: IEntity
    {
    }
