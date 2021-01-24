    public class Startup
    {
    
        // This will be your application instance
        IBus bus;
    
        public void ConfigureServices(IServiceCollection services)
        {  
            // Create, assign the Bus, and add it as Singleton to your application
            bus = RabbitHutch.CreateBus("host=localhost");
            // now you can easyly inject in your components
            services.AddSingleton(bus);
        }
    
        public void Configure(IHostApplicationLifetime lifetime)
        {
            // Start receiving messages from the queue
            bus.Receive<MyMessage>("my-queue", message => Console.WriteLine("MyMessage: {0}", message.Text));
    
            // Hook your custom shutdown the the lifecycle
            lifetime.ApplicationStopping.Register(OnShutdown);
        }
        private void OnShutdown()
        {
            // Dispose the Bus
            bus.Dispose();
        }
    }
