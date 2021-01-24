`
    public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging(logging => {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            })
            .UseNLog()
            .UseStartup<Startup>()
            .Build();
`
And in Startup.cs:
`
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseServiceStack(new AppHost
            {
                AppSettings = new NetCoreAppSettings(Configuration)
            });
            LogManager.LogFactory = new NetCoreLogFactory(loggerFactory, true);
        }
`
The service layers can then call upon this definition by calling LogManager.GetLogger(GetType()). The issue then is how the LogFactory would be defined.
I have tried to use Microsoft's own Application Insights logging, but in the end I settled with going for NLog with using Application Insights as a target, as shown in the above code.
The code works now and I can see data going into Application Insights.
