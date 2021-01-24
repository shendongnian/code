    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using TestError.Infrastructure;
    namespace TestError
    {
        public class Startup
        {
            //   Updated this class for ASP.NET Core 3
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddControllersWithViews();
                services.AddRazorPages();
            }
            public void Configure(IApplicationBuilder app, IHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                     app.UseDeveloperExceptionPage();
                }
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseMiddleware<ErrorHandler>();
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(name: "Default", 
                                                    pattern: "{controller=Home}/{action=Home}/{id?}");
                
                    endpoints.MapControllerRoute(name: "Error",
                                                    "error",
                                                    new { controller = "Home", action = "Error" });
                    endpoints.MapControllerRoute(name: "PageNotFound",
                                                    "pagenotfound",
                                                    new { controller = "Home", action = "PageNotFound" });
                });
            }
        }
    }
