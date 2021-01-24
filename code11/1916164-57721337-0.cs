    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
            var facorty = new CustomQueueProcessorFactory();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
            });
            builder.ConfigureServices(s => s.AddSingleton<IQueueProcessorFactory>(facorty));
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            });
            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
    public class CustomQueueProcessorFactory : IQueueProcessorFactory
    {
        public QueueProcessor Create(QueueProcessorFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Queue.Name.ToString() == "queue")
            {
                context.MaxDequeueCount = 10;
            }
            else if (context.Queue.Name.ToString() == "queue1")
            {
                context.MaxDequeueCount = 10;
                context.BatchSize = 1;
            }
            return new QueueProcessor(context);
        }
    }
