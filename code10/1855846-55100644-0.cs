cs
internal class MySignalRService : IHostedService, IDisposable
{
    private readonly IHubContext _hubContext;
    
    public MySignalRService(IHubContext hubContext)
    {
        _hubContext = hubContext;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        //Setup some scheduler to do your job
        return Task.CompletedTask;
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
    }
    public void Dispose()
    {
    }
}
And then
cs
services.AddHostedService<MySignalRService>();
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.1
