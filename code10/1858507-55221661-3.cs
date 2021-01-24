    public void ConfigureServices(IServiceCollection services)
    {
      //Added for session state
      services.AddDistributedMemoryCache();
       
      services.AddSession(options =>
      {
      options.IdleTimeout = TimeSpan.FromMinutes(10);               
      });
    }
