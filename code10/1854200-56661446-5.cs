    public void ConfigureServices(IServiceCollection services)
    {
       services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
       services.Configure<ConfigSettings>(Configuration.GetSection(nameof(ConfigSettings)));
    }
