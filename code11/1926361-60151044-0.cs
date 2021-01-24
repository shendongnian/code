    public class EntityBase<TId>
    { 
        // ... 
    }
    public interface INode
    {
        ICollection<INode> Children { get; }
    }
    public class Entity<TParentId,TChildId> : EntityBase<TParentId>, INode
    {
        public ICollection<INode> Children { get; } = new List<INode>();
    }
