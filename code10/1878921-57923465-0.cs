public class BusEnvironmentNameFormatter : IEntityNameFormatter
    {
        private readonly IEntityNameFormatter _original;
        private readonly string _prefix;
        public ServiceBusEnvironmentNameFormatter(IEntityNameFormatter original, SomeAppSettingsSection busSettings)
        {
            _original = original;
            _prefix = string.IsNullOrWhiteSpace(busSettings.Environment)
                ? string.Empty // no prefix
                : $"{busSettings.Environment}:"; // custom prefix
        }
        // Used to rename the exchanges
        public string FormatEntityName<T>()
        {
            var original = _original.FormatEntityName<T>();
            return Format(original);
        }
        // Use this one to rename the queue
        public string Format(string original)
        {
            return string.IsNullOrWhiteSpace(_prefix)
                ? original
                : $"{_prefix}{original}";
        }
    }
Then to use it, we would do something like this:
            var busSettings = busConfigSection.Get<SomeAppSettingsSection>();
            var rabbitMqSettings = rabbitMqConfigSection.Get<SomeOtherAppSettingsSection>();
            services.AddMassTransit(scConfig =>
            {
                scConfig.AddConsumers(consumerAssemblies);
                scConfig.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(rmqConfig =>
                {
                    rmqConfig.UseExtensionsLogging(provider.GetRequiredService<ILoggerFactory>());
                    // Force serialization of default values: null, false, etc
                    rmqConfig.ConfigureJsonSerializer(jsonSettings =>
                    {
                        jsonSettings.DefaultValueHandling = DefaultValueHandling.Include;
                        return jsonSettings;
                    });
                    var nameFormatter = new ServiceBusEnvironmentNameFormatter(rmqConfig.MessageTopology.EntityNameFormatter, busSettings);
                    var host = rmqConfig.Host(new Uri(rabbitMqSettings.ConnectionString), hostConfig =>
                    {
                        hostConfig.Username(rabbitMqSettings.Username);
                        hostConfig.Password(rabbitMqSettings.Password);
                    });
                    // Endpoint with custom naming
                    rmqConfig.ReceiveEndpoint(host, nameFormatter.Format(busSettings.Endpoint), epConfig =>
                    {
                        epConfig.PrefetchCount = busSettings.MessagePrefetchCount;
                        epConfig.UseMessageRetry(x => x.Interval(busSettings.MessageRetryCount, busSettings.MessageRetryInterval));
                        epConfig.UseInMemoryOutbox();
                        //TODO: Bind messages to this queue/endpoint
                        epConfig.MapMessagesToConsumers(provider, busSettings);
                    });
                    // Custom naming for exchanges
                    rmqConfig.MessageTopology.SetEntityNameFormatter(nameFormatter);
                }));
            });
