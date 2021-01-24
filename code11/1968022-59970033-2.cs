    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("MyBackgroundService is starting.");
    
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("MyBackgroundService task doing background work.");
    
            var success = await DoOperation(i);
            if (!success)
            {
                // Try again in 5 seconds
                await Task.Delay(5000, stoppingToken);
                continue;
            }
    
            break;
        }
    }
