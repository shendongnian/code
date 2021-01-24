    public class TermHostedService : BackgroundService {
        private readonly ILogger<TermHostedService> _logger;
    
        public TermHostedService(IServiceProvider services, 
            ILogger<ConsumeScopedServiceHostedService> logger) {
            Services = services;
            _logger = logger;
        }
    
        public IServiceProvider Services { get; }
    
        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            _logger.LogInformation("Term Hosted Service running.");
    
            using (var scope = Services.CreateScope()) {
                var term = scope.ServiceProvider.GetRequiredService<ITerm>();    
                await term.LoadData();
                _logger.LogInformation("Data Loaded.");
            }
        }
    
        public override async Task StopAsync(CancellationToken stoppingToken) {
            _logger.LogInformation("Term Hosted Service is stopping.");    
            await Task.CompletedTask;
        }
    }
