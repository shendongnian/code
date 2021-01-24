    public static class FunctionReadFromTableStorage
        {
            [FunctionName("FunctionReadFromTableStorage")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                //Read Request Body
                var content = await new StreamReader(req.Body).ReadToEndAsync();
    
                //Extract Request Body and Parse To Class
                MyPoco objMyPoco = JsonConvert.DeserializeObject<MyPoco>(content);
    
                // Validate param because PartitionKey and RowKey is required to read from Table storage In this case , so I am checking here.
                dynamic validationMessage;
    
                if (string.IsNullOrEmpty(objMyPoco.PartitionKey))
                {
                    validationMessage = new OkObjectResult("PartitionKey is required!");
                    return (IActionResult)validationMessage;
                }
                if (string.IsNullOrEmpty(objMyPoco.RowKey))
                {
                    validationMessage = new OkObjectResult("RowKey is required!");
                    return (IActionResult)validationMessage;
                }
    
    
                // Table Storage operation  with credentials
                var client = new CloudTableClient(new Uri("https://YourStorageURL.table.core.windows.net/"),
                          new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("YourStorageName", "xtaguZokAWbfYG4QDkBjT+YourStorageKey+T/kId/Ng+cl3TfYHtg=="));
                var table = client.GetTableReference("YourTableName");
    
                //Query filter
                var query = new TableQuery()
                {
                    FilterString = string.Format("PartitionKey eq '{0}' and RowKey eq '{1}'", objMyPoco.PartitionKey, objMyPoco.RowKey)
                };
    
    
                //Request for storage query with query filter
                var continuationToken = new TableContinuationToken();
                var storageTableQueryResults = new List<TableStorageClass>();
                foreach (var entity in table.ExecuteQuerySegmentedAsync(query, continuationToken).GetAwaiter().GetResult().Results)
                {
                    var request = new TableStorageClass(entity);
                    storageTableQueryResults.Add(request);
                }
    
                //As we have to return IAction Type So converting to IAction Class Using OkObjectResult We Even Can Use OkResult
                var result = new OkObjectResult(storageTableQueryResults);
                return (IActionResult)result;
            }
        }
