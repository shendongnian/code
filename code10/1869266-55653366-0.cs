    public void ConfigureServices(IServiceCollection services)
    {
	
	...
	
	services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie("user_by_cookie", options =>
             {
                 options.LoginPath = "/Login/Index/";
             })
	...
	
	
	}
	
	
	
	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
	...
	 app.UseAuthentication();
     app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Dashboard}/{action=Index}/{id?}");
	 });
	...
	}
