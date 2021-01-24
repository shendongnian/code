    public class LogService : HostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public LogBackgroundService (IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await new QuickLog().AsyncConsumer(cancellationToken); 
                await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            }
        }
    }
