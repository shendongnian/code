    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder hostBuilder) {
            var serviceProvider = hostBuilder.Services.BuildServiceProvider();
            var configurationRoot = serviceProvider.GetService<IConfiguration>();
            var configurationBuilder = new ConfigurationBuilder();
            var appConfigEndpoint = configuration["AppConfigEndpoint"];
            if (configurationRoot is IConfigurationRoot) {
                configurationBuilder.AddConfiguration(configurationRoot);
            }
            if (!string.IsNullOrEmpty(appConfigEndpoint)) {
                configurationBuilder.AddAzureAppConfiguration(appConfigOptions => {
                    // possible to run this locally with ClientSecretCredential
                    appConfigOptions.Connect(new Uri(appConfigEndpoint), new ManagedIdentityCredential());
                });
            }
            var configuration = configurationBuilder.Build();
            hostBuilder.Services.Replace(ServiceDescriptor.Singleton(typeof(IConfiguration), configuration));
            // Do more stuff with Configuration here...
        }
    }
    public sealed class HelloFunction
    {
        private IConfiguration Configuration { get; }
        public HelloFunction(IConfiguration configuration) {
            Configuration = configuration;
        }
        [FunctionName("HelloFunction")]
        public void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log) {
            log.LogInformation($"Timer Trigger Fired: 'Hello {Configuration["Message"]}!'");
        }
    }
