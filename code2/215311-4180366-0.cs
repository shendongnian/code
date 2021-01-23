    sealed class EFRepository<TEntity> : Repository<TEntity>
        where TEntity : EntityObject
    {
        ObjectContext _context;
        ObjectSet<TEntity> _entitySet;
        IAuditor _auditor;
        public EFRepository(ObjectContext context) : this(context, null)
        {
        }
        public EFRepository(ObjectContext context, IAuditor auditor)
        {
            _context = context;
            _entitySet = _context.CreateObjectSet<TEntity>();
            _auditor = auditor; 
        }
        public override void Create(TEntity entity)
        {
            _entitySet.AddObject(entity);
            _context.SaveChanges();
            if (_auditor != null)
            {
                // audit
            }
        }
    
        // etc.
    }
