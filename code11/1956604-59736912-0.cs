C#
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...
    app.UseStaticFiles(); // <<=== MUST INCLUDE THIS LINE
    ...
}
**2) Program.cs > CreateHostBuilder() method** must include `webBuilder.UseStaticWebAssets();`
C#
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStaticWebAssets(); // <<=== MUST INCLUDE THIS LINE
                webBuilder.UseStartup<Startup>();
            });
}
\#2 is what I was missing. I'm not sure if I just missed that in the documentation or if they recently updated it to include that, but either way that fixed it for me.
