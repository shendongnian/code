	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers(); // <-- this changed
		services.AddDbContext<AppDbContext>(options => {
			options.UseInMemoryDatabase("market-api-in-memory");
		});
		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<ICategoryService, CategoryService>();
	}
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
        // Routing is added from your version:
		app.UseRouting();
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});
	}
