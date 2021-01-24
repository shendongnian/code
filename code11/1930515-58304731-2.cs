    public IConfiguration _config { get; }
    
    public Startup(IHostingEnvironment env)
    {
        _environmentPath = env.ContentRootPath;
    
        _config = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appSettings.json").Build();
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        Config.ConnectionString = _config["ConnectionString"];
    }
