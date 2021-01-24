    public class Repository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
    
        public Repository(DbContext context)
        {
            _context = context;
        }
    
        public List<TResult> GetEntities<TResult>(Expression<Func<TEntity, TResult>> selector) where TResult : class
        {
            return _context.Set<TEntity>().Select(selector).ToList();
        }
    }
