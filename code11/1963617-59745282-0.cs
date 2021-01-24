    public Startup(IConfiguration configuration, AppSettings appSettings)
    {
         Configuration = configuration;
    }
    
    public AppSettings AppSettings { get; set; }
    
    public void ConfigureServices(IServiceCollection services)
    {
         AppSettings = new AppSettings();
         Configuration.GetSection("AppSettings").Bind(AppSettings); //if it is section in settings or else bind all json data
         AppSettings.cacheDirPath = Path.Combine(Directory.GetCurrentDirectory(),
         Configuration.GetValue<string>("GitLab:cache_dir_name"));
         services.AddSingleton<AppSettings>(AppSettings);
         DirectoryInfo di = new DirectoryInfo(AppSettings.cacheDirPath);
         if (!di.Exists)
         {
              di.Create();
         }
    }
