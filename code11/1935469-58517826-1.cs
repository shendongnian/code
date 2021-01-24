    namespace MyApp.Interfaces
    {
        public class StartupShutdownHandler
        {
    
            public static IWebHostBuilder BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).
                ConfigureKestrel(serverOptions =>{}).UseIISIntegration()
                .UseStartup<StartupShutdownHandler>();
    
            private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    
    
            public StartupShutdownHandler(IConfiguration configuration)
            {
                Configuration = configuration;
            }
    
            public IConfiguration Configuration { get; }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                services.AddControllers(options => options.RespectBrowserAcceptHeader = true).AddXmlSerializerFormatters().AddXmlDataContractSerializerFormatters(); //updated            
                CorsRelatedPolicyAddition(services);
            }
    
            private void CorsRelatedPolicyAddition(IServiceCollection services)
            {
                var lstofCors = ConfigurationHandler.GetSection<List<string>>(StringConstants.AppSettingsKeys.CorsWhitelistedUrl);
                if (lstofCors != null && lstofCors.Count > 0 && lstofCors.Any(h => !string.IsNullOrWhiteSpace(h)))
                {
                    services.AddCors(options =>
                    {
                        options.AddPolicy(MyAllowSpecificOrigins, builder => { builder.WithOrigins(lstofCors.ToArray()).AllowAnyMethod().AllowAnyHeader(); });
                    });
    
                }
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseRouting();
                app.UseCors(MyAllowSpecificOrigins);
                app.UseEndpoints(endpoints =>
                {                
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });            
                applicationLifetime.ApplicationStarted.Register(StartedApplication);
                applicationLifetime.ApplicationStopping.Register(OnShutdown);
            }
    
    
            private void OnShutdown()
            {
                 Logger.Debug("Application Ended");
            }
    
            private void StartedApplication()
            {
                Logger.Debug("Application Started");
            }
        }
    }
