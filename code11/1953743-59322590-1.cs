        public void ConfigureServices(IServiceCollection services)
        {
            .........
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "You api title", Version = "v1" });
                c.AddSecurityDefinition("api key", new ApiKeyScheme() // key name must match the one you supply to preauthorizeApiKey call in JS
                {
                    Description = "Authorization query string expects API key",
                    In = "query",
                    Name = "authorization",
                    Type = "apiKey"
                });
                var requirements = new Dictionary<string, IEnumerable<string>> {
                    { "api key", new List<string>().AsEnumerable() }
                };
                c.AddSecurityRequirement(requirements);
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.IndexStream = () => File.OpenRead("wwwroot/swashbuckle.html"); // this is the important bit. see documentation https://github.com/domaindrivendev/Swashbuckle.AspNetCore/blob/master/README.md
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); // very standard Swashbuckle init
            });
            app.UseMvc();
        }
