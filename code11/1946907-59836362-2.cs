    public void ConfigureServices(IServiceCollection services)
        {
            if (HostingEnvironment.EnvironmentName == "Local")
            {
                services.AddHealthChecksUI()
               .AddHealthChecks()
               .AddCheck<TestWebApiControllerHealthCheck>("HomePageHealthCheck")
               .AddCheck<DatabaseHealthCheck>("DatabaseHealthCheck");
            }
        services.Configure<PwdrsSettings>(Configuration.GetSection("MySettings"));
        services.AddDbContext<PwdrsContext>(o => o.UseSqlServer(Configuration.GetConnectionString("PwdrsConnectionRoot")));
        services.AddMvc(o =>
        {
            o.Filters.Add<CustomExceptionFilter>();
        });
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", b => b
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        });
        services.AddSwaggerDocument();
        services.AddHttpContextAccessor();
        services.AddAutoMapper(typeof(ObjectMapperProfile));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
        services.AddScoped<IRfReportTypeRepository, RfReportTypeRepository>();
        services.AddScoped<IRfReportRepository, RfReportRepository>();
        services.AddScoped<IRfReportLookupsService, RfReportLookupsService>();
        services.AddScoped<IRfReportService, RfReportService>();
        RegisterSerilogLogger logger = CreateRegisterSerilogLogger(services);
    }
    private RegisterSerilogLogger CreateRegisterSerilogLogger(IServiceCollection services){
    	    services.Configure<RAFLogging>(Configuration.GetSection("RAFLogging"));
            ServiceProvider serviceProvider = services.BuildServiceProvider(); //No warning here ))
            IOptions<RAFLogging> RAFLogger = serviceProvider.GetRequiredService<IOptions<RAFLogging>>();
            RegisterSerilogLogger logger = new RegisterSerilogLogger(RAFLogger);
    	return logger;
    }
