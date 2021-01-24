    public void ConfigureServices(IServiceCollection services)
    {
            services.AddMvc();
    
            // app settings configuration.
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    var corsUrlSection = Configuration.GetSection("AllowedOrigins");
                    var corsUrls = corsUrlSection.Get<string[]>();
                    policy.WithOrigins(corsUrls)
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination") // add any customer header if we are planning to send any 
                        .AllowAnyMethod();
                });
            });
    
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment environment, ILoggerFactory loggerFactory)
    {
            app.UseExceptionMiddleware();
    
            // Use HTTPS Redirection Middleware to redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();
    
            app.UseCors("AllowSpecificOrigin");
       
            app.UseMvc();
    
    }
