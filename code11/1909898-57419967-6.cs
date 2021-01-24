    public class ScopedExecutor
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<ScopedExecutor> _logger;
        public ScopedExecutor(
            IServiceScopeFactory serviceScopeFactory,
            ILogger<ScopedExecutor> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }
        public async Task<T> ScopedAction<T>(Func<IServiceProvider, Task<T>> action)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                return await action(scope.ServiceProvider);
            }
        }
        
        public async Task ScopedAction(Func<IServiceProvider, Task> action)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                await action(scope.ServiceProvider);
            }
        }
    }
