    public class ContextFactory<T> : IContextFactory<T> where T : DbContext
    {
        public T CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            optionsBuilder.UseSqlServer(connectionString);
            return (T)Activator.CreateInstance(typeof(T), optionsBuilder.Options);
        }
    }
