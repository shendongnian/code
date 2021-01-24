    using System;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace example
    {
        class Program
        {
            static void Main(string[] args)
            {
                // create service collection
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
    
                var serviceProvider = serviceCollection.BuildServiceProvider();
    
                serviceProvider.GetService<Startup>().Run();
            }
    
            private static void ConfigureServices(IServiceCollection serviceCollection)
            {
                // add services
                serviceCollection.AddTransient<IMyService, MyService>();
    
                serviceCollection.AddTransient<Startup>();
            }
        }
    }
