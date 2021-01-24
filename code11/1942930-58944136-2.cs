    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IUnitOfWork UnitOfWork { get; }
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        // ...
     }
