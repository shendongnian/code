    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create(string contextType)
        {
            switch (contextType)
            {
                case "SiteModelContainer":
                    return new UnitOfWork<SiteModelContainer>();
                case "AnotherModelContainer":
                    return new UnitOfWork<AnotherModelContainer>();
            }
            throw new ArgumentException("Unknown contextType...");
        }
    }
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext, new()
    {
        private TContext _dbContext;
        public UnitOfWork()
        {
            _dbContext = new TContext();
        }
        public IRepository<TEntity> CreateGenericRepository<TEntity>()
            where TEntity : class
        {
            return new Repository<TEntity>(_dbContext);
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private DbContext _dbContext;
        private DbSet<T> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        // etc.
    }
