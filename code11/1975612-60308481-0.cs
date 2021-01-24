    public void ConfigureServices(IServiceCollection services)
    {
         services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
         {
          builder.AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowAnyOrigin()
                 .AllowCredentials();
            }));
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
            });
      }}
     public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DiagnosticListener diagnosticListenerSource, DiagnosticObserver diagnosticObserver)
     {
            app.UseCors("MyPolicy");
     }
