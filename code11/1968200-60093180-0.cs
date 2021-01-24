    public class Startup : FunctionsStartup
    {
        private IConfigurationRoot _functionConfig = null;
        private IConfigurationRoot FunctionConfig( string appDir ) => 
            _functionConfig ??= new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(appDir, "appsettings.json", optional: true, reloadOnChange: true)).Build();
        public override void Configure(IFunctionsHostBuilder builder)
        {
             builder.Services.AddOptions<MachineLearningSettings>()
                 .Configure<IOptions<ExecutionContextOptions>>((mlSettings, exeContext) =>
                     FunctionConfig(exeContext.Value.AppDirectory).GetSection("MachineLearningSettings").Bind(mlSettings) );
        }
    }
