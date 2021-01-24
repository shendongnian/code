    public void ConfigureServices(IServiceCollection services) {
        services.AddMvc().AddControllersAsServices();
        services.AddSingleton<ModulePermissionHelper>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ITagModuleRepository, TagModuleRepository>();
        //..
        services.AddDbContext<xxxContext>(options => ...);
    }
