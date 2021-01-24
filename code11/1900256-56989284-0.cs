    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // This is the line you want to add!
                .UseKestrel(x =>
                {
                    x.Limits.MaxRequestHeadersTotalSize = <your value?>;
                })
                .UseStartup<Startup>();
    }
