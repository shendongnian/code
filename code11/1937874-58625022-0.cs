json
{
  "Devices": [
    { "Name": "D1" },
    { "Name": "D2" },
    { "Name": "D3" },
    { "Name": "D4" }
  ]
}
`CreateHostBuilder()`:
csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.Configure<List<DeviceConfig>>(hostContext.Configuration.GetSection("Devices"));
            services.AddHostedService<Worker>();
        });
**Worker:**
public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly List<DeviceConfig> config;
        public Worker(IOptions<List<DeviceConfig>> options, ILogger<Worker> logger)
        {
            config = options.Value;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach(var device in config)
                {
                    // TODO: Process each device here
                    _logger.LogInformation("Processing device {name}", device.Name);
                }
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
-----
If your current `RemoteDevice` class has state information, create a `List<RemoteDevice>` in the worker and initialize from configuration.
