    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("MyBackgroundService is starting.");
    
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("MyBackgroundService task doing background work.");
    
            for (var i = 0; i < 10; i++)
            {
                _logger.LogInformation($"Testing ${i}");
                await someAsyncOperation(i);
            }
    
            break;
        }
    }
