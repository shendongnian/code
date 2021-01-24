    public void ConfigureServices(IServiceCollection services) {
        var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
    
        Configuration = builder.Build(); //<--
    
        // services.AddTransient<GetAcumuladoController>();
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        services.AddDbContext<ApplicationDBContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
        );
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        } else {
            app.UseHsts();
        }
    
        app.UseHttpsRedirection();
        app.UseMvc();
    }
