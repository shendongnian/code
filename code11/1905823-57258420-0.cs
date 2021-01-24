    public class Startup
    {
       ...
        public void ConfigureServices(IServiceCollection services)
        {
			...
            services.AddSpaStaticFiles(configuration =>
            {
			    //configuration.RootPath = "ClientApp/build"; <-- this relative path resolves wrong 
                configuration.RootPath = "/var/aspnetcore/publish/ClientApp/build";
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           ...
            app.UseSpa(spa =>
            {
                //spa.Options.SourcePath = "ClientApp"; <-- this relative path resolves wrong
                spa.Options.SourcePath = "/var/aspnetcore/publish/ClientApp"; 
				...
            });
        }
    }
	
