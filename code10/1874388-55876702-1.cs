    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private JobsLedgerAPIContext _context;
    
        public string ConnectionString { get; set; }
    
        public EntityBaseRepository(IContextFactory<JobsLedgerAPIContext> factory)
        {
            _context = factory.CreateDbContext(ConnectionString);
        }
        
        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
    
        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }
    }
