	public IServiceCollection ConfigureServices(IServiceCollection services)
	{
		services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		services.AddContexts();
		services.AddCommonServices();
		services.AddOtherServices();
		return services;
	}
