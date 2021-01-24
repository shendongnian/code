        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options =>
            {       
                options.Cookie.IsEssential = true;
            });
            ...
        }
