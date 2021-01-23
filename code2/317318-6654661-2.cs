    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create(string contextType);
    }
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> CreateGenericRepository<TEntity>()
            where TEntity : class;
        void Commit();
    }
    public interface IRepository<T>
    {
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Attach(T entity);
        void Add(T entity);
        // etc.
    }
