    public class HostedServiceConfig
    {
         public bool RunService1 { get; set; }
    }
    
    services.Configure<HostedServiceConfig>(Configuration.GetSection("HostedService"));
