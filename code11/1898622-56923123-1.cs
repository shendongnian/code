    abstract class Repository
    {
        protected Dictionary<object, IEntity> entities;
    
        protected Repository()
        {
            entities = new Dictionary<object, IEntity>();
        }
    
        public virtual void Add(IEntity entity) 
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            entities.Add(entity.GetId(), entity);
        }
    
        public virtual IEntity Get(object id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return entities[id];
        }
    }
    
    abstract class Repository<TId, TEntity> : Repository 
        where TEntity : class, IEntity<TId>
    {
        protected Repository() : base() { }
    
        public override void Add(IEntity entity)
        {
            Add((TEntity)entity);
        }
    
        public override IEntity Get(object id)
        {
            return Get((TId)id);
        }
    
        public void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            entities.Add(entity.GetId(), entity);
        }
    
        public TEntity Get(TId id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return (TEntity)entities[id];
        }
    }
