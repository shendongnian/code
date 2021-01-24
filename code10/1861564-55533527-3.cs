    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected GenericRepository(IApplicationDbContext<T> context)
        {
            _dbContext = context;
        }
        private TApplicationDbContext<T> _dbContext;
        private static IEnumerable<T> entity;
        public IEnumerable<T> Get(bool forceRefresh = false)
        {
            if (forceRefresh || entity == null)
                entity = _dbContext.Set<T>();
            return entity;
        }
        public async Task AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
