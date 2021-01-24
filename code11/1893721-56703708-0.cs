    using System;
    using Microsoft.Extensions.Configuration;
    
    namespace testapp
    {
        class Program
        {            
            static void Main(string[] args)
            {
               var appSettings = new Config();
               var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();  
                config.Bind(appSettings);        
    
                Console.WriteLine("Hello World!");
                Console.WriteLine($" Hello {config.name} !"); 
            }
        }
        public class Config
        {
           public string name{ get; set; }
        }
    }
