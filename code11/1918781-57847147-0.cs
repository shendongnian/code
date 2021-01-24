    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System.Data.SqlClient;
    using System.Text;
    using System.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.WindowsAzure.Storage.Table;
    
    namespace TestFunapp
    {
        public static class Function1
        {
            # install package Microsoft.Azure.WebJobs.Extensions.Storage
            [FunctionName("Function1")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
                [Table("People")] CloudTable cloudTable,
                ILogger log, ExecutionContext  context)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
          
                string name = req.Query["name"];
                TableOperation retrieveOperation = TableOperation.Retrieve<People>("Jim", "Xu");
    
                TableResult retrievedResult = await cloudTable.ExecuteAsync(retrieveOperation);
                if (retrievedResult.Result != null)
                    log.LogInformation(((People)retrievedResult.Result).Email);
               
                else
                    log.LogInformation("The Email could not be retrieved.");
    
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                name = name ?? data?.name;
              
                return name != null
                    ? (ActionResult)new OkObjectResult($"Hello, {name}")
                    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }
        }
        public class People : TableEntity
        {
    
            public People(string lastName, string firstName)
            {
                this.PartitionKey = lastName;
                this.RowKey = firstName;
            }
    
            public People() { }
    
            public string Email { get; set; }
    
        }
    }
