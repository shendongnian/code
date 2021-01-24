    public static void Main(string[] args) {
        var host = new HostBuilder()
              .ConfigureHostConfiguration(configHost => {
              })
              .ConfigureServices((hostContext, services) => {
                  services.AddHostedService<IHostedService, RabbitLister>();
              })
             .UseConsoleLifetime()
             .Build();
        //run the host
        host.Run();
    }
