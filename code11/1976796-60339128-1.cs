    using Microsoft.Azure.WebJobs;
    
    namespace WebJob1
    {
        
        class Program
        {
            
            static void Main()
            {
                var config = new JobHostConfiguration();
                config.UseServiceBus();
    
                if (config.IsDevelopment)
                {
                    config.UseDevelopmentSettings();
                    
                }
    
                var host = new JobHost(config);
                // The following code ensures that the WebJob will be running continuously
                host.RunAndBlock();
            }
        }
    }
