    public class UnitOfWork<T> : IUnitOfWork<T>
        where T : DbContext, new()
    {
        private T _context;
        private readonly IDatabaseFactory<T> _databaseFactory;
        protected T Context
        {
            get { return _context ?? (_context = _databaseFactory.Get()); }
        }
        public UnitOfWork(IDatabaseFactory<T> factory)
        {
            _databaseFactory = factory;
            _context = _databaseFactory.Get();
        }
        //More code
    }
    public class DatabaseFactory<T> : Disposable, IDatabaseFactory<T>
        where T : DbContext, new()
    {
        private T _dataContext;
        public T Get()
        {
            return _dataContext ?? (_dataContext = new T());
        }
        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
