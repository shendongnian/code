csharp
// BackgroundService is a base-class implementation of IHostedService
// You will find it in the package Microsoft.Extensions.Hosting.Abstractions
public class QueueWorkerService : BackgroundService
{
    private readonly IServiceProvider serviceProvider;
    // this could be anything you choose to fullfill the task!
    private readonly ISomeQueueProvider queueProvider;
    public QueueWorkerService(IServiceProvider serviceProvider, ISomeQueueProvider queueProvider)
    {
        this.serviceProvider = serviceProvider;
        this.queueProvider = queueProvider;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (!queueProvider.Tasks.Any())
            {
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                continue;
            }
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
            
            foreach (var task in queueProvider.Tasks)
            {
                // do logic 
                await context.Set<SomeEntity>().AddAsync(someObject);
            }
        }
    }
}
Keep in mind this implementation is more like pseudo-code. For the queues you could really use anything. 
  [1]: https://blog.stephencleary.com/2014/06/fire-and-forget-on-asp-net.html
  [2]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.0&tabs=visual-studio
