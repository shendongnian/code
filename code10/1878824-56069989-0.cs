    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddDbContext<dbApplicationServiceNavada>(options => options.UseMySql(Configuration.GetConnectionString("ASNConnStr")));
        ....
    }
