    interface IEntity
    {
        object GetId();
    }
    
    interface IEntity<TId> : IEntity
    {
        new TId GetId();
    }
    abstract class EntityBase<TId> : IEntity<TId>
    {
        protected TId id;
    
        protected EntityBase(TId id)
        {
            this.id = id;
        }
    
        public TId GetId() => id;
    
        object IEntity.GetId() => GetId();
    }
