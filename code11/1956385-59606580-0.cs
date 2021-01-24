        private IConfiguration Configuration { get; }
		public Startup(IWebHostEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}
    	public void ConfigureServices(IServiceCollection services)
		{
			_appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
			services.AddSingleton(_appSettings);
            ...
        }
