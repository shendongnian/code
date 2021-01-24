    public class PersistedConfigurationService : IPersistedConfigurationService
    {
        private readonly IServiceProvider _serviceProvider;
        public PersistedConfigurationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task Foo()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                 var context = scope.ServiceProvider.GetRequiredService<IPersistedConfigurationDbContext>();
                 // do something with context
            }
        }
    }
