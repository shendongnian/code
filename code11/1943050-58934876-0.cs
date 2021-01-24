    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IMessageReceiver, MessageReceiver>();
                    services.AddSingleton<IWebhookMessageForwarder, WebhookMessageForwarder>();
                    services.AddHostedService<Worker>();
                });
    }
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMessageReceiver _messageReceiver;
        private readonly IWebhookMessageForwarder _forwarder;
        public Worker(IMessageReceiver messageReceiver,
            IWebhookMessageForwarder forwarder)
        {
            _messageReceiver = messageReceiver;
            _forwarder = forwarder;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                System.Console.WriteLine("Hello");
                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
            }
        }
    }
    public interface IWebhookMessageForwarder
    {
    }
    public class WebhookMessageForwarder : IWebhookMessageForwarder
    {
    }
    public interface IMessageReceiver
    {
    }
    public class MessageReceiver : IMessageReceiver
    {
    }
