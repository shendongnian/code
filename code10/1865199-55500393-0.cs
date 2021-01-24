    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.Management.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace RSFunctionCallingFluent
    {
        public static class SimpleFunction
        {
            [FunctionName("SimpleFunction")]
            public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
            {
                AzureCredentialsFactory factory = new AzureCredentialsFactory();
                AzureCredentials msiCred = factory.FromMSI(new MSILoginInformation(MSIResourceType.AppService), AzureEnvironment.AzureGlobalCloud);
                var azure = Azure.Configure().WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic).Authenticate(msiCred).WithDefaultSubscription();
    
                var nsg = azure.NetworkSecurityGroups.GetByResourceGroup("TestNSGRG", "RSTestNSG1");
    
                return (ActionResult)new OkObjectResult(string.Format("NSG {0} found with {1} default security rules", nsg.Name, nsg.DefaultSecurityRules.Count));
            }
        }
    }
