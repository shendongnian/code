    using Microsoft.Extensions.DependencyInjection;
    public class SomeService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public SomeService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public Task DoStuff()
        {
            using (var serviceScope = _serviceScopeFactory.CreateScope())
            {
                var unitOfWork =  serviceScope.ServiceProvider.GetRequiredService<UnitOfWork>();
            }
        }
    }
