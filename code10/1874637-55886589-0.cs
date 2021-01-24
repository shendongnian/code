    public class ContextFactory<TContext> : IContextFactory<TContext>
        where TContext : DbContext, new() {
        public TContext Create(string connectionString) {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return (TContext)Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);
        }
    }
