C#
public sealed class MyService : BackgroundService
{
  private readonly IHostApplicationLifetime _hostApplicationLifetime;
  private readonly ILogger<MyService> _logger;
  public MyService(IHostApplicationLifetime hostApplicationLifetime, ILogger<MyService> logger)
  {
    _hostApplicationLifetime = hostApplicationLifetime;
    _logger = logger;
  }
  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    try
    {
      while (!stoppingToken.IsCancellationRequested)
      {
        try
        {
          _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
          await SomeMethodThatDoesTheWork(stoppingToken);
        }
        catch (Exception ex)
        {
          _logger.LogError(ex, "Global exception occurred. Will resume in a moment.");
        }
        await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
      }
    }
    finally
    {
      _logger.LogCritical("Exiting application...");
      _hostApplicationLifetime.StopApplication();
    }
  }
}
