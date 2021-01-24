    public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Properties", "launchSettings.json"));
            Configuration = builder.Build();
        }
    public IConfiguration Configuration { get; }
 
