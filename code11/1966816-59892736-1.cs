public class MoveViewHub : Hub
{
    private readonly IServiceProvider provider
    
    public MovieViewHub(IServiceProvider provider)
    {
        this.provider = provider
    }
}
Then you can do something like this:
    public override Task OnConnectedAsync()
    {
        Console.WriteLine("Client has connected");
 
        // you need to inject service provider to your hub, then get hub context from
        // registered services
        using (var scope = this.provider.CreateScope())
        {
            // get instance of hub from service provider
            var scopedServices = scope.ServiceProvider;
            var hub = scopedServices.GetRequiredService<IHubContext<MoveViewHub>>
            // pass hub to class constructor
            RfidClass rfidClass = new RfidClass(hub)
            rfidClass.sas();
            RfidClass.SendTagNumber += ReceiveTagNumber;
        }
       
        System.Diagnostics.Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Notepad++", @"notepad++.exe"));
        return base.OnConnectedAsync();
    }
**EDIT:**
If you just want to `SignalR` work, you dont need to work on `Hub`. Instead make service. In this service inject `HubContext<>` of your `Hub`:
    // you need to make your own class and interface and inject hub context
    public interface ISignalRService
    {
        Task SendMessageToAll(string message);
    }
    public class SignalRService : ISignalRService
    {
        private readonly IHubContext<YourHub> hubContext;
        public SignalRService (IHubContext<NotificationHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        public async Task SendMessageToAll(string message)
        {
            await this.hubContext.Clients.All.SendAsync("ReciveMessage", message);
        }
    }
Then register that service in your `Startup` class:
    services.AddScoped<ISignalRService, SignalRService>();
After that you can call `SignalRService` wherever you want to like normal service from .NetCore DI container:
private readonly ISignalRService notificationService;
public SomeController(ISignalRService notificationService)
{
    this.notificationService = notificationService;
}
[HttpGet]
public async Task<IActionResult> Send()
{
    await this.notificationService.SendMessageToAll("message");
    return Ok();
}
You dont need to make some wark around like `RfidClass`.
