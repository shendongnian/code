    public Repository<T> where T : class, IEntity
    {
        private ObjectSet<T> _set;          // or DbSet
        private ObjectContext _context;  // or DbContext
 
        public Repository(ObjectContext context) // or DbContext
        {
            _context = context;
            _set = context.CreateObjectSet<T>();  // _context.Set<T>() for DbContext                     
        }
        public IQueryable<T> GetQuery()
        {
            return _set;
        }
        public T Get(int id)
        {
            return _set.SingleOrDefault(e => e.Id == id);
        }
        public void Add (T entity)
        {
            _set.AddObject(entity);
        }
        public void Update(T entity)
        {
            _set.Attach(entity);
            context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            // or context.Entry(entity).State = EntityState.Modified; for DbContext
        }
        public void Delete(entity)
        {
            _set.Attach(entity);
            _set.DeleteObject(entity);
        }
    }
