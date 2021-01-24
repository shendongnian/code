public class SomeTimedService : Microsoft.Extensions.Hosting.BackgroundService
{
    public IHubContext<EstablishmentsHub> HubContext { get; set; }
    public SomeTimedService(IHubContext<EstablishmentsHub> hubcontext)
    {
        HubContext = hubcontext;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await this.dataFlowHub.Clients.All.BroadcastStatus("ayl-3", 10);
            await Task.Delay(10000);
        }
    }
}
Keep in mind that this will (in the worst case) delay the shutdown of the application by 10 seconds. You could do a loop for lets say 500ms and check each time if it has been canceled.  
You'd place this instead of the `Task.Delay(10000)`: 
for (int i = 0; i < 20; i++)
{
    if (stoppingToken.IsCancellationRequested) break;
    await Task.Delay(500);
}
I would also suggest you to use [strongly-typed hubs](https://docs.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-2.2#strongly-typed-hubs) since they have a lot of benefits.
