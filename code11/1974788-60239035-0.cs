    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json",
                            optional: false,
                            reloadOnChange: true)
            .AddEnvironmentVariables();
        if (env.IsDevelopment())
        {
            builder.AddUserSecrets<Startup>(); // this line adds secrets to configuration
        }
        Configuration = builder.Build();
        var a = Configuration["PW"]; // value: test
    }
