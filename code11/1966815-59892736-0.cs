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
