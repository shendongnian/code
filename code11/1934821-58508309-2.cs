    using System.IO;
    using Infragistics.Web.Mvc;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Server.Kestrel.Core;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    namespace IgUpload
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc(options => options.EnableEndpointRouting = false);
                services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
                services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);
                services.Configure<UploadAppSettings>(options =>
                {
                    options.maxFileSizeLimit = "1073741824"; // 1 GB
                    options.FileUploadPath = $@"{Directory.GetCurrentDirectory()}\Data\UploadedFiles";
                });
            }
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseUploadModuleMiddleware();
                app.UseUploadHandlerMiddleware();
                app.UseMvc(routes => routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"));
            }
        }
    }
