    public static void Main(string[] args)
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                var serviceProvider = serviceCollection.BuildServiceProvider();
    
                var app = serviceProvider.GetService<Application>();
                app.Run();
                Console.Read(); // So the application will not exit and there will be time for the background thread to do its job
            }
