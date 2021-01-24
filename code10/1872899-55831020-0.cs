csharp
public static async Task Main(string[] args)
{
    Console.WriteLine("Starting");
    var host = new HostBuilder()
        .ConfigureServices((hostContext, services) =>
        {
           services.AddHostedService<DaemonService>();
        });
    System.IO.File.WriteAllText("/path-to-app/_main.txt", "Line 1");
    await host.RunConsoleAsync();
}
`
`csharp
public class DaemonService : IHostedService, IDisposable
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        System.IO.File.WriteAllText("/path-to-app/_Start.txt", "Line 1");
        return Task.CompletedTask;
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
            return Task.CompletedTask;
    }
    public void Dispose()
    {
        try
        {
            System.IO.File.WriteAllText("/path-to-app/_Dispose.txt", "Line 1");
            System.IO.File.WriteAllText("/path-to-app/_Stop.txt", "Line 1");
        }
        finally
        {
            System.IO.File.WriteAllText("/path-to-app/_main-finally.txt", "Line 1");
        }
    }
}
`
As this is running as a service we came to the conclusion that it actually made sense to contain the finalisation of the service itself within that scope, similar to the way ASP.NET Core applications function by providing just the service inside the `Program.cs` file and allowing the service itself to maintain its dependencies.
My advice would be to contain as much as you can in the service and just have the `Main` method initalise it.
