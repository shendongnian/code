    public class InitializeCacheService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public InitializeCacheService (IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var cache = _serviceProvider.GetService<IMemoryCache>();
                cache.Set("key1", "value1");
            }
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
Add it in your ConfigureServices
services.AddHostedService<InitializeCacheService>();
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.2
