    public class MyRepositoryProvider<TEntity> : Provider<IMyRepository<TEntity>>
        where TEntity : MyBaseEntity
    {
        private ApplicationDbContext _applicationDbContext;
    
        public MyRepositoryProvider(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    
        protected override IMyRepository<TEntity> CreateInstance(IContext context)
        {
            return new MyRepository<TEntity>(_applicationDbContext);
        }
    }
