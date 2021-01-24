    public interface IEntity
    {
        // ...
    }
    public class Entity<TId>: IEntity
    {
        public TId Id { get; private set; }
        public Type ChildrenType { get; private set; }
        // ... 
    }
    public static class Tree
    {
        static private Dictionary<IEntity, ICollection<IEntity>> ChildCollections = new Dictionary<IEntity, ICollection<IEntity>>();
        static private Dictionary<IEntity, IEntity> Parents = new Dictionary<IEntity,IEntity>();
        static public ICollection<IEntity> GetChildren(this IEntity parent) => Tree.ChildCollections.ContainsKey(parent) ? this.ChildCollections[parent] : null;
        static public IEntity GetParent(this IEntity child) => Tree.Parents.ContainsKey(child) ? this.Parents[child] : null;
        static public void AddChild<TParentId,TChildId>( this Entity<TParentId> parent, Entity<TChildId> child)
        {
            if (!parent.ChildrenType.IsAssignableFrom(child.GetType())) { throw new InvalidOperationException("Child is not of correct type"); }
            if (Tree.Parents.ContainsKey(child)) { throw new InvalidOperationException("Child already has a parent"); }
            Tree.Parents.Add(child, parent);
            if (!Tree.ChildCollections.ContainsKey(parent)) {
                Tree.ChildCollections.Add(parent, new Collection<IEntity>());
            }
            Tree.ChildCollections[parent].Add(child);
        }
        static public void RemoveChild( this IEntity parent, IEntity child)
        {
            // ...
        }
    }
