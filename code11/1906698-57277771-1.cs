	public IServiceCollection ConfigureServices(IServiceCollection services)
	{
		services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
		services.AddDbContext<CoreContext>(options => options.UseMySql(Configuration.GetConnectionString("Core")));
		services.AddDbContext<CoreReadOnlyContext>(options => options.UseMySql(Configuration.GetConnectionString("CORE_READONLY")));
		services.AddDbContext<StatsContext>(options =>
			options.UseMySql(Configuration.GetConnectionString("Stats")));
		
		services.AddScoped<ProfileTokenGenerator>();
		services.AddTransient<MailNotificationService>();
		services.AddTransient<RegisterControllerService>();
        services.AddScoped<OtherClass>();
		services.AddTransient<MoreTransient>();
		services.AddTransient<ThingsService>();
		return services;
	}
