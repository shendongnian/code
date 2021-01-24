    public class SendMailHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<SendMailHostedService> _logger;
        private Timer _timer;
    
        public SendMailHostedService(ILogger<SendMailHostedService> logger)
        {
            _logger = logger;
        }
    
        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service running.");
    
            _timer = new Timer(DoWork, null, TimeSpan.Zero, 
                TimeSpan.FromSeconds(5));
    
            return Task.CompletedTask;
        }
    
        private void DoWork(object state)
        {
            //...Your stuff here
    
            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", executionCount);
        }
    
        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");
    
            _timer?.Change(Timeout.Infinite, 0);
    
            return Task.CompletedTask;
        }
    
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
