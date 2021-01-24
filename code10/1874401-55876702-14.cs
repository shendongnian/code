    public class ContextFactory<T> : IContextFactory<T> where T : DbContext
    {
        private readonly HttpContext _httpContext;
        public ContextFactory(IHttpContextAccessor contextAccessor)
        {
            _httpContext = contextAccessor.HttpContext;
        }
        public T CreateDbContext()
        {
            // retreive the connectionString from the _httpContext.Items
            // this is saved in the controller action method
            var connectionString = (string)_httpContext.Items["connection-string"];
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            optionsBuilder.UseSqlServer(connectionString);
            return (T)Activator.CreateInstance(typeof(T), optionsBuilder.Options);
        }
    }
