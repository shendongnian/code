    public IConfiguration Configuration { get; set; }
    public IHostingEnvironment Environment { get; set; }
    
    public Startup(IConfiguration configuration, IHostingEnvironment environment)
    {
       Environment = environment;
       Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.secrets.json")
                .Build();
    }
