    public class ContextFactory<TContext>
        where TContext : DbContext
    {
        private readonly Func<TContext> _createContext;
        public ContextFactory(Func<TContext> createContext)
        {
            _createContext = createContext ?? throw new ArgumentNullException(nameof(createContext));
        }
        TContext CreateForRead()
        {
            var context = Create();
            context.ChangeTracker.AutoDetectChangesEnabled = false;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return context;
        }
        TContext CreateForWrite() => Create();
        private TContext Create()
        {
            var context = _createContext();
            if (context == null)
                throw new NullReferenceException($"{nameof(_createContext)} must not return null.");
            return context;
        }
    }
