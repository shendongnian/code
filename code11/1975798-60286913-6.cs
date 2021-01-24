    public class LogBackgroundService : IHostedService
    {
    
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await QuickLog.AsyncConsumer(); // or whatever you want to call           
        }
    
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
