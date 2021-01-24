     public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddAuthorization();
            services.AddAuthentication("Bearer")
              .AddJwtBearer("Bearer", options =>
              {
                  options.Authority = "http://localhost:5000";
                  options.RequireHttpsMetadata = false;
                  options.Audience = "api1";
              });
        }
