    public static readonly Dictionary<string, string> _dict = 
        new Dictionary<string, string>
        {
            {"Policy:roles:0:name", "doctor"},
            {"Policy:roles:0:subjects:0", "1"},
            {"Policy:roles:0:subjects:1", "2"},
            {"Policy:roles:1:name", "patient"},
            {"Policy:roles:1:identityRoles:0", "customer"},
        };
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddInMemoryCollection(_dict);
            })
            .UseStartup<Startup>();
