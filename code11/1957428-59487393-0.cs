c#
services.AddHostedService<Worker>();
The worker class:
c#
protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    while (!stoppingToken.IsCancellationRequested)
    {
        await this.hub.Clients.All.SendAsync(broadcastMethodName, "Some message...");
        await Task.Delay(2000, stoppingToken);
    }
}
