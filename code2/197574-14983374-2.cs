    public class ContextWrapper<TContext> : IDisposable
        where TContext : ObjectContext
    {
        private TContext _context;
        private EntityConnectionManager _manager;
        private bool _disposed;
    
        public ContextWrapper()
            : this(true)
        {
        }
    
        public ContextWrapper(bool lazyLoadingEnabled)
        {
            _disposed = false;
            _manager = new EntityConnectionManager();
            _context = (TContext)Activator.CreateInstance(typeof(TContext), _manager.Connection);  
            _context.ContextOptions.LazyLoadingEnabled = lazyLoadingEnabled;
        }
    
        ~ContextWrapper()
        {
            Dispose(false);
        }
    
        public TContext Context
        {
            get { return _context; }
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
    
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_manager != null)
                    {
                        _manager.Dispose();
                        _manager = null;
                    }
                    var ctx = _context as IDisposable;
                    if (ctx != null)
                    {
                        ctx.Dispose();
                        _context = null;
                    }
                }
            }
            _disposed = true;
        }
    }
