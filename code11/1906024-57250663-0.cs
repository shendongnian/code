            public void ConfigureServices(IServiceCollection services)
            {
                // Web API Culture Configuration
                RequestCulture rc = new RequestCulture("en-US");
                CultureInfo ci = rc.Culture;
                DateTimeFormatInfo dtfi = ci.DateTimeFormat;
                dtfi.AbbreviatedDayNames = new String[] { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };
                services.Configure<RequestLocalizationOptions>(options =>
                {
                    options.DefaultRequestCulture = rc;
                });
                // Other configurations
                ....
                ....
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
    
                app.UseRequestLocalization();
    
                app.UseMvc();
            }
