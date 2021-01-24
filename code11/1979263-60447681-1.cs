    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");
        services.AddControllers().AddViewLocalization(
        LanguageViewLocationExpanderFormat.Suffix,
        opts => { opts.ResourcesPath = "Resources"; })
        .AddDataAnnotationsLocalization();
            
        services.Configure<RequestLocalizationOptions>(options => {
            var supportedCultures = new CultureInfo[] {
                new CultureInfo("en"),
                new CultureInfo("de"),
                new CultureInfo("fr")
        };
            options.DefaultRequestCulture = new RequestCulture("en");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
            options.RequestCultureProviders = new[]{ new CustomRouteDataRequestCultureProvider{
                IndexOfCulture=1,
            }};
        });                      
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(options.Value);
        app.UseHttpsRedirection();
        app.UseRouting();
            
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapControllerRoute("LocalizedDefault", "{culture:cultrue}/{controller=Home}/{action=Index}/{id?}");
                
        });          
    }
