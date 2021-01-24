    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.Configure<ConnectionStringConfig>(Configuration);
        services.AddHttpClient("externalservice", c =>
        {
            // Assume this is an "external" service which requires an API KEY
            c.BaseAddress = new Uri("https://localhost:5001/");
        });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api For RoundTable A Complete ERP for warehouse managment", Version = "v1" });
        });
        services
            .AddControllersWithViews()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        services.AddControllers().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
    }
