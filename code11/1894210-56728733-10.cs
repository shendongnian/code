    class Program {
        static async Task Main(string[] args) {
    
            var services = new ServiceCollection();
    
            //...
    
            services.AddHttpClient<IDependency, Dependency>();
            services.AddScoped<Job1>();
            services.AddTransient<ISchedulerFactory, StdSchedulerFactory>();
            services.AddTransient<IJobFactory>(serviceProvider => new JobFactory(serviceProvider)); 
            services.AddTransient<IHostedService, SchedulerService>();
            
            //...
        
            IServiceProvider serviceProvider = services.BuildServiceProvider();
        
            var service = serviceProvider.GetRequiredService<IHostedService>(); 
            await service.StartAsync();
        
            Console.ReadKey();
    
        }
    }
    
