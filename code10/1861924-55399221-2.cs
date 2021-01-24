    public class MyTestStartup : Startup
        {
    
            public MyTestStartup(IConfiguration configuration)
            {   
                Configuration = configuration;
            }
    
            protected override void RegisterDatabase(IServiceCollection services)
            {
                    services.AddScoped<IMyDbProcessor>(db => new TestDbProcessor());
            }
        }
