      public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
                {
                    services.AddRazorPages();
                }
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
                {
                    app.UseRouting();
                    app.UseEndpoints(endpoints => endpoints.MapRazorPages());
                    app.UseEndpoints(endpoints =>
                                                 {
                                                   endpoints.MapControllerRoute("default", " 
                                                   {controller=Home}/{action=Index}/{id?}");
                                                  });                 
                }
        }
