    public class EntityBase<TId>
    { 
        // ... 
    }
    public interface INode
    {
        IEnumerable<INode> Children { get; }
    }
    public class Entity<TParentId,TChildId> : EntityBase<TParentId>, INode
    {
        public ICollection<EntityBase<TChildId>> Children { get; } = new List<EntityBase<TChildId>>();
        IEnumerable<INode> INode.Children => this.Children.Cast<INode>();
    }
 
