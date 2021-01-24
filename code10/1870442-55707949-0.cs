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
