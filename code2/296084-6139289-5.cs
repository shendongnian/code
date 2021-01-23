    public abstract class BaseRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        public BaseRepository(DatabaseContext context)
        {
        }
    }
