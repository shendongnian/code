    public interface IEntity: IEquatable<IEntity>
    {
        // ...
    }
    public class Entity<TId,TChild>: IEntity
    where TChild: IEntity
    {
        public TId Id { get; private set; }
        public ICollection<TChild> Children { get; } = new Collection<TChild>();
        // ...
    }
