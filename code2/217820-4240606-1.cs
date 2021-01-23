    public class Repository<TDataContext, TEntity> : IDisposable
        where TDataContext : DataContext
        where TEntity : class
    {
        protected TDataContext DataContext { get; private set; }
        public Repository(TDataContext dataContext)
        {
            DataContext = dataContext;
        }
        ...
    }
