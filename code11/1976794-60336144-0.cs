        static void Main()
        {
            var config = new JobHostConfiguration("your storage connection string ");
            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
                
            }
            config.UseServiceBus(new ServiceBusConfiguration() { ConnectionString = "your servcebus connection string " });
            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    `
