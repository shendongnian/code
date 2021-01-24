public class SomeTimedService : Microsoft.Extensions.Hosting.BackgroundService
{
    private IHubContext<EstablishmentsHub> _hubContext;
    public SomeTimedService(IHubContext<EstablishmentsHub> hubcontext)
    {
        _hubContext = hubcontext;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _hubContext.Clients.All.BroadcastStatus("ayl-3", 10);
            await Task.Delay(10000);
        }
    }
}
Keep in mind that this will (in the worst case) delay the shutdown of the application by 10 seconds. You could do a loop for lets say 500ms and check each time if it has been canceled.  
You'd place this instead of the `Task.Delay(10000)`: 
for (int i = 0; i < 20; i++)
{
    if (stoppingToken.IsCancellationRequested) return;
    await Task.Delay(500);
}
I would also suggest you to use [strongly-typed hubs](https://docs.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-2.2#strongly-typed-hubs) since they have a lot of benefits.  
A full solution (including all you've written about your application) would be like this:   
// background service for sending a (currently hardcoded) status every 10 seconds to every client
public class EstablishmentsService : Microsoft.Extensions.Hosting.BackgroundService
{
    private IHubContext<EstablishmentsHub, IEstablishmentsClient> _hubContext;
    public EstablishmentsService(IHubContext<EstablishmentsHub, IEstablishmentsClient> hubcontext)
    {
        _hubContext = hubcontext;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _hubContext.Clients.All.ReceiveStatus("ayl-3", 10);
            for (int i = 0; i < 20; i++)
            {
                if (stoppingToken.IsCancellationRequested) return;
                await Task.Delay(500);
            }
        }
    }
}
// the client of the hub. Here you place methods which should be called by the application.
public interface IEstablishmentsClient
{
    Task ReceiveStatus(string someString, int someInt);
}
// the hub itself. You'd place methods here which should be called from the client
public class EstablishmentsHub : Hub<IEstablishmentsClient>
{
        
}
Inside `Startup.ConfigureServices(IServiceCollection services)` you need to call:  
services.AddHostedService<EstablishmentsService>();
