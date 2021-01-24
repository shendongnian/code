    public Startup(IHostingEnvironment env) {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        Configuration = builder.Build();
    }
    IConfiguration Configuration;
    public void ConfigureServices(IServiceCollection services) {
        // Add framework services.
        services.AddMvc();
        // Add AWS services
        var options = Configuration.GetAWSOptions();
        services.AddDefaultAWSOptions(options);
        services.AddAWSService<IAmazonSQS>();
        services.AddAWSService<IAmazonDynamoDB>();
     
        services.AddSingleton<IEmailQueueService, EmailQueueService>();
        
        //...omitted for brevity
    }
    
