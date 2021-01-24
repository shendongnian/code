    public void ConfigureServices(IServiceCollection services)
    {
         ...
         services.AddAutoMapper(new Assembly[] {
                  typeof(SomeProject.AutoMapperProfile).Assembly,
                  typeof(SomeOtherProject.AutoMapperProfile).Assembly
                });
         ...
    }
