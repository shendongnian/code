     public void ConfigureServices(IServiceCollection services)
            {
                ...
                // JWT
                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes("MySpecialKey")),
                        ValidIssuer = "MainServer",
                        ValidAudience = "Sample",
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
                ...
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                ...
                app.UseAuthentication();
                ...
            }
