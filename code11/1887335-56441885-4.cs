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
    private readonly YourSQLThingy _sqlThingy;
    public EstablishmentsHub(YourSQLThingy sQLThingy)
    {
        _sqlThingy = sQLThingy;
    }
    public SomeObject GetFirstObject()
    {
        return _sqlThingy.Whatever.First();
    }
    public void SomeHubMethod()
    {
        // do something here
    }
}
Inside `Startup.ConfigureServices(IServiceCollection services)` you need to call:  
services.AddHostedService<EstablishmentsService>();
Of course you'll have to add the js too. In my project I used some code to register the signalR-url in the `Configure` method of the Startup-class:  
app.UseSignalR(routes =>
{
   routes.MapHub<EstablishmentsHub>("/establishmentsSignalR");
});
In the js you can now get the hub using that same url (there are other ways without the url almost certainly but I did it this way): 
var connection = new signalR.HubConnectionBuilder().withUrl("/establishmentsSignalR").build();
After you get this connection you have the possibility to use `connection.on(xxxx, ..)` for all the client methods and `connection.xxxx(..)` for all the hub methods.  
In this example here you would do the following:  
connection.on("ReceiveStatus", function (someString, someInt) {
    // do whatever with those two values
    // if it's a bigger object it will simply be converted to a jsonObject
});
Now you've set what happens on the clientside. You can now start the connection using `connection.start();`.  
Note that in the js you can call the methods defined in the hub simply by using `connection.SomeHubMethod()` (I added that method to the hub in the full solution). If you use parameters/return values it's all converted between json and c# objects.
That's all you need to do, not that much :).  
We're getting there. You have now removed every non-public method which isn't supposed to be used with remoting, very good. These methods were something with sql so you are supposed to place them into a seperate class with a good name that tells that it's for retrieving data.  
Let's say you have your class defined and filled. What you need to do now, is register it to the DI-system. With db-stuff you usually want a singleton but I can't decide for that without seeing what the class contains/does.  
You can register the class inside the `ConfigureServices` method in the Startup-class. `services.AddSingleton<YourSQLThingy>();`  
Now the DI-system knows your class and you can simply inject it anywhere you want. For that place it into the Hubs constructor (I updated the "full" solution"). The DI-system will automatically find the registered class when activating your hub and inject it just like that. Note that since you're using singleton here, it will always be the same instance which gets injected!
