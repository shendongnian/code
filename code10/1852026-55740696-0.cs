        // file startup.cs
        using Microsoft.Extensions.Logging.AzureAppServices;
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                //...
                services.Configure<AzureFileLoggerOptions>(Configuration.GetSection("AzureLogging"));
            } 
        }
     File `appsettings.json` should contain
        "AzureLogging": {
             "FileName" : "azure-diagnostics-",
             "FileSizeLimit": 50024,
             "RetainedFileCountLimit": 5
        }
