    public class ContextFactory<TContext> : IContextFactory<TContext>
        where TContext : DbContext {
        public TContext Create(DbContextOptions<TContext> options) {
            return (TContext)Activator.CreateInstance(typeof(TContext), options);
        }
    }
