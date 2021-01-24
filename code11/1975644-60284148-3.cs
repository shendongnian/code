    public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAuthorizationCore();
             services.AddScoped<TokenProvider>();
            services.AddHttpClient();
        }
