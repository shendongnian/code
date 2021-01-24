    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        _logger.LogInformation("Consume Scoped Service Hosted Service is working.");
        while (!stoppingToken.IsCancellationRequested) {
            using (var scope = Services.CreateScope()) {
                IServiceProvider serviceProvider = scope.ServiceProvider;
                var service = serviceProvider.GetRequiredService<IScopedProcessingService>();    
                await service.DoWork(stoppingToken);
            }
            //Add a delay between executions.
            await Task.Delay(SomeIntervalBetweenCalls);
        }
    }
