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
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddEnvironmentVariables()
                 .AddJsonFile("appsettings.json", true, true)
                 .Build();
               config.Bind(appSettings); 
               Console.WriteLine($" Hello {appSettings.name} !");
            }
        }
        public class Config
        {
           public string name{ get; set; }
        }
    }
