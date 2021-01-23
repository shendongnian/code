    public class BaseRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        public BaseRepository(DatabaseContext context)
        {
        }
    }
