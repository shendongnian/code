    public class BackgroundService1 : BackgroundService
        {
            private int executionCount = 0;
            private readonly ILogger<BackgroundService1> _logger;
            private Timer _timer;
    
            public BackgroundService1(ILogger<BackgroundService1> logger)
            {
                _logger = logger;
            }
    
            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation($"BackgroundService 1 start to work. Thread ID : {Thread.CurrentThread.ManagedThreadId} Count: {executionCount}");
                    executionCount++;
                    _logger.LogInformation($"BackgroundService 1 done work. Thread ID : {Thread.CurrentThread.ManagedThreadId} Count: {executionCount}");
                    await Task.Delay(100, stoppingToken);
                }
            }
