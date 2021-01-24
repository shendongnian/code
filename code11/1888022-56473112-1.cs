    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.WindowsAzure.Storage.Table;
    
    namespace AzureFunctionsSandbox
    {
        public class MyPoco : TableEntity
        {
            public string Body { get; set; }
        }
    
        public static class Function1
        {
            [FunctionName("Function1")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                [Table("Sandbox", "StorageConnectionString")] CloudTable table,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    
                var poco = new MyPoco { PartitionKey = "HttpTrigger", RowKey = Guid.NewGuid().ToString(), Body = requestBody };
    
                var insertOperation = TableOperation.Insert(poco);
    
                await table.ExecuteAsync(insertOperation);
    
                return new OkObjectResult($"PK={poco.PartitionKey}, RK={poco.RowKey}, Text={poco.Body}");
            }
        }
    }
