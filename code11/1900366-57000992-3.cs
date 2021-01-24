    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
    }
