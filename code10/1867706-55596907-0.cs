    public void ConfigureServices(IServiceCollection services)
    {
         services.RegisterCustomContracts();
         services.RegisterCustomServices();
         services.RegisterRepositories();
         services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
         
         // configure the system messages
         services.Configure<ShortenUrlConfig>(Configuration.GetSection("ShortenUrlConfig"));
         services.AddEntityFramework(Configuration.GetConnectionString("TestDBContext"));
    }    
  
