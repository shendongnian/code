    public class Startup : FunctionsStartup
    {
        private static IConfiguration Configuration { get; }
        public override void Configure(IFunctionsHostBuilder hostBuilder) {
            var serviceProvider = hostBuilder.Services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            var configurationBuilder = new ConfigurationBuilder();
            var appConfigEndpoint = configuration["AppConfigEndpoint"];
            if (configuration is IConfigurationRoot configurationRoot) {
                configurationBuilder.AddConfiguration(configurationRoot);
            }
            if (!string.IsNullOrEmpty(appConfigEndpoint)) {
                configurationBuilder.AddAzureAppConfiguration(appConfigOptions => {
                    // possible to run this locally with ClientSecretCredential
                    appConfigOptions.Connect(new Uri(appConfigEndpoint), new ManagedIdentityCredential());
                });
            }
            Configuration = configurationBuilder.Build();
            hostBuilder.Services.Replace(ServiceDescriptor.Singleton(typeof(IConfiguration), Configuration));
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
