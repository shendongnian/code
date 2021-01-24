    // This method gets called by the runtime. Use this method to add services to the container.
    
    public void ConfigureServices(IServiceCollection services)
    {
        // You need to comment this out ..
        // services.AddRazorPages();
        // And need to write this instead:
        services.AddMvc().AddRazorPagesOptions(options =>
        {
            options.Conventions.AddPageRoute("/Login/Index", "");
        });
    }
