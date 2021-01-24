    public static void Main(string[] args)
    {
        var builder = CreateWebHostBuilder(args);
        var host = builder.Build(); 
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
    
            var aws = services.GetService<AwsConfigurationBuilder>();
    
        }
