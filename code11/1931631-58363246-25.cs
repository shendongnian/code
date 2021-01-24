    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using TestError.Infrastructure;
    namespace TestError
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
            }
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                     app.UseDeveloperExceptionPage();
                }
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseMiddleware<ErrorHandler>();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(name: "Default",
                                     template: "{controller=Home}/{action=Home}/{id?}");
                    routes.MapRoute(name: "Error",
                                     template: "error",
                                     defaults: new { controller = "Home", action = "Error" });
                    routes.MapRoute(name: "PageNotFound",
                                     template: "pagenotfound",
                                     defaults: new { controller = "Home", action = "PageNotFound" });
               });
            }
        }
    }
