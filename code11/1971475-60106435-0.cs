        public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddCors();
            ...
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ...
            app.UseCors(options =>
                options.WithOrigins("https://localhost:44395")
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            ...
        }
