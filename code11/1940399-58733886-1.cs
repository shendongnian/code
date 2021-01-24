    public class Program {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            var hostbuilder = new HostBuilder()
                .UseWindowsService()
                .ConfigureAppConfiguration((hostingContext, config) => {
                    var path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    config
                        .SetBasePath(path)
                        .AddJsonFile("appsettings.json");
                })
                .ConfigureLogging(
                    options => options.AddFilter<EventLogLoggerProvider>(level => 
                        level >= LogLevel.Information)
                )
                .ConfigureServices((hostContext, services) => {
                    //get settings from app configuration.
                    ImporterSettings settings = hostContext.Configuration.Get<ImporterSettings>();
                    
                    services
                        .AddSingleton(settings) //add to service collection
                        .AddHostedService<Importer>()
                        .Configure<EventLogSettings>(config => {
                            config.LogName = "Application";
                            config.SourceName = "Importer";
                        });
                });
    #if (DEBUG)
            await hostbuilder.RunConsoleAsync();
    #else
            await hostbuilder.RunAsServiceAsync();
    #endif
        }
    }
