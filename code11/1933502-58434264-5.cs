    public class MyService : BackgroundService
    {
        readonly ILogger<MyService> _logger;
        public MyService(ILogger<MyService> logger)
        {
            _logger=logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int count = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInfo($"Hit count: {++count}, IsCancellationRequested: {stoppingToken.IsCancellationRequested}");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            _logger.LogInfo($"IsCancellationRequested: {stoppingToken.IsCancellationRequested}");
            _logger.LogInfo("The end.");
        }
    }
