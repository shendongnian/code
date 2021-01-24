    public void Configure(IApplicationBuilder app, IHostingEnvironment env,IHttpContextAccessor httpContextAccessor, 
        IOptions<MailSettings> mailConfig, IOptions<ApplicationSettings> applicationSettings,ILoggerFactory loggerFactory)
    {
      
       GlobalDiagnosticsContext.Set("connectionString", ConnectionString.Connection);
       loggerFactory.AddNLog();
	   app.UseMvc();
    }
