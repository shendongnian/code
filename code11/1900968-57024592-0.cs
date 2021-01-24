    public class CoreTestContextFactory
    {
        private readonly IServiceProvider _sp;
        public CoreTestContextFactory(IServiceProvider sp)
        {
            _sp = sp;
        }
        public CoreTestContext CreateDbContext()
        {
            return _sp.GetRequiredService<DataContext>();
        }
    }
