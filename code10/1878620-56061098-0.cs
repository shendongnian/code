      public IHostingEnvironment HostingEnvironment { get; }
    
        public void ConfigureServices(IServiceCollection services)
        {
            if (HostingEnvironment.IsDevelopment())
            {
                services.AddTransient<ITestService, TestService>();
            }
            else
            {
                services.AddTransient<IRealService, RealService>();
            }
    
            // other services
        }
