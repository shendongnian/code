    // This method gets called by the runtime. Use this method to add services to the container.
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().AddRazorPagesOptions(options =>
        {
            options.Conventions.AddPageRoute("/Login/Index", "");
        });
    }
