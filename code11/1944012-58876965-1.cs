c#
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace WebApp 
{
  public class Program
  {
    public static async Task<int> Main(string[] args) {
      try {
        var host = new WebHostBuilder()
          .UseKestrel()
          .UseUrls("http://localhost:5000/;https://localhost:5001")
          .ConfigureServices(_configureServices)
          .Configure(_configure)
          .Build();
        await host.RunAsync();
        return 0;
      }
      catch {
        return -1;
      }
    }
    static Action<IServiceCollection> _configureServices = (services) => {
         services.AddControllersWithViews();
    };
    static Action<IApplicationBuilder> _configure = app => {
      app.UseRouting();
 
      app.UseEndpoints(endpoints =>
      {
          endpoints.MapControllers();
      });
      app.Run((ctx) => ctx.Response.WriteAsync("Page not found."));
    };
  }
}
`
This also takes advantage of the new async capabilities of the entry point `Main(string[] args)`, wraps the server startup in a try/catch, and registers a catch-all not found handler.
