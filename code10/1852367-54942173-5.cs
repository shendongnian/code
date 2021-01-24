     public class Program
        {
            public static void Main(string[] args)
            {
                BuildWebHost(args).Run();
            }
    
            public static IWebHost BuildWebHost(string[] args)
            {
                var clientInfo = ClientInfo.Load();
    
                return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .ConfigureServices(services =>
                    {
                        services.AddSingleton(clientInfo);
                    })
                    .Build();
            }
        }
