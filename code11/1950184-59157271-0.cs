    public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    
                services.AddSwaggerGen(x =>
                {
                    x.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Your API", Version = "v1" });
    
                    var filePath = Path.Combine(AppContext.BaseDirectory, "YourApi.xml");
                    x.IncludeXmlComments(filePath);
    
                    x.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = "header", 
                        Type = "apiKey"
                        
                    });
                    x.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                    {
                        { "Bearer", new string[] { } }
                        
                    });
    
                });
    
              
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
                services.AddSingleton<IConfiguration>(Configuration);
                services.AddSession();
    
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseHsts();
                }
    
                var swaggerOptions = new Options.SwaggerOptions();
                Configuration.GetSection(nameof(Options.SwaggerOptions)).Bind(swaggerOptions);
    
                app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
    
                app.UseSwaggerUI(option =>
                {
                    option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
    
                    option.OAuthClientId("swagger-ui");
                    option.OAuthClientSecret("swagger-ui-secret");
                    option.OAuthRealm("swagger-ui-realm");
                    option.OAuthAppName("Swagger UI");
                });
                app.UseHttpsRedirection();
    
    
                app.UseMiddleware<AuthenticationMiddleware>();
    
                app.UseSession();
                app.UseMvc();
               
            }
 
