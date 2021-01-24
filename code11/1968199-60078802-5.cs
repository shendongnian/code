    public class Startup : FunctionsStartup {
        public override void Configure(IFunctionsHostBuilder builder) {
            builder.ConfigureHostConfiguration((sp, config) => {
                var executioncontextoptions = sp.GetService<IOptions<ExecutionContextOptions>>().Value;
                var currentDirectory = executioncontextoptions.AppDirectory;
                
                config
                    .SetBasePath(currentDirectory)
                    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
                
                //if there are multiple settings files, consider extracting the list,
                //enumerating it and adding them to the configuration builder.
            });
            
            builder.Services
                .AddOptions<MachineLearningConfig>()
                .Configure<IConfiguration>((settings, configuration) => {
                    configuration.GetSection("MachineLearningConfig").Bind(settings);
                });
        }
    }
    
