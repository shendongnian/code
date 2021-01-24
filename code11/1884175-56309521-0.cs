    public void ConfigureServices(IServiceCollection services)
    {
          services.AddCors();
          services.AddMvc();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseCors(
            options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );
    
        app.UseMvc();
    }
