using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureLogging((logging) =>
    {
        // clear default logging providers
        logging.ClearProviders();
    })
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });
