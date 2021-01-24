    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public static class WebHostExtensions
    {
        public static IWebHost SomeExtension(this IWebHost webHost)
        {
            var config = webHost.Services.GetService<IConfiguration>();
            // Your initialisation code here.
            // ...
            return webHost;
        }
    }
