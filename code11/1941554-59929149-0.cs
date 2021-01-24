public class HealthCheckWorker : BackgroundService
{
    private readonly int _intervalSec;
    private readonly string _healthCheckFileName;
    public HealthCheckWorker(string healthCheckFileName, int intervalSec)
    {
        this._intervalSec = intervalSec;
        this._healthCheckFileName = healthCheckFileName;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            File.WriteAllText(this._healthCheckFileName, DateTime.UtcNow.ToString());
            await Task.Delay(this._intervalSec * 1000, stoppingToken);
        }
    }
}
Then you can add a extension method like this:
public static class HealthCheckWorkerExtensions
{
    public static void AddHealthCheck(this IServiceCollection services,
        string healthCheckFileName, int intervalSec)
    {
        services.AddHostedService<HealthCheckWorker>(x => new HealthCheckWorker(healthCheckFileName, intervalSec));
    }
}
With this you can add in services the health check support
.ConfigureServices(services =>
{
    services.AddHealthCheck("hc.txt", 5);
})
