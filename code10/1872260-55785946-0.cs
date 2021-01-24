    public interface IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> FindAsync(TEntity entity);
        IQueryable<TEntity> Entities { get; }
        // etc.
    }
    // The read-write version inherits from the read-only interface.
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        void Update(TEntity entity);
        void Insert(TEntity entity);
        // etc.
    }
