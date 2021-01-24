     public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                //// Set a short timeout for easy testing.
                //options.IdleTimeout = TimeSpan.FromMinutes(10);
                //options.Cookie.HttpOnly = true;
                //// Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
     }
    public void Configure(IApplicationBuilder app)
    {
         //...
         app.UseSession();
         app.UseAddHeader();
         //...
    }
