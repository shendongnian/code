// in Stratup
var config = new ConfigurationBuilder()
     ..SetBasePath(Environment.CurrentDirectory)
     .AddJsonFile("app.settings.json", optional: true, reloadOnChange: true)
     .AddEnvironmentVariables()
     .Build();
in other class
public MyService(IConfiguration configuration){
  var emailConfig = configuration.GetSection("Email");
  var userName = emailConfig["Username"];
}
When we deploy the web app to Azure, we can directly save these settings and connection strings in the [Application settings][1]. Then we can read them as environment variables. 
include Microsoft.Extensions.Configuration;
namespace SomeNamespace 
{
    public class SomeClass
    {
        private IConfiguration _configuration;
    
        public SomeClass(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        public SomeMethod()
        {
            // retrieve App Service app setting
            var myAppSetting = _configuration["MySetting"];
            // retrieve App Service connection string
            var myConnString = _configuration.GetConnectionString("MyDbConnection");
        }
    }
}
  [1]: https://docs.microsoft.com/en-us/azure/app-service/configure-common?toc=%2Fazure%2Fapp-service%2Fcontainers%2Ftoc.json#configure-app-settings
