    public void ConfigureServices(IServiceCollection services)
        {
            // ...
            services.AddSignalR();
        }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           app.UseEndpoints(endpoints =>
            {
                // ...
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
