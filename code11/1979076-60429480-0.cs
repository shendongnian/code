     public class StartUp:IHostedService
     {
        private readonly IHostApplicationLifetime _host;
        private ILogger<StartUp> _logger;
        public StartUp(IHostApplicatiomLifeTime host, ILogger<StartUp> logger)
        {
            _host = host;
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("start async");
            _host.StopApplication();
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("stop async");
            return Task.CompletedTask;
        }
    }
