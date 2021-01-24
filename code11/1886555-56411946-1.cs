    public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                //Read Request Body
                var content = await new StreamReader(req.Body).ReadToEndAsync();
    
                //Extract Request Body and Parse To Class
                Users objUsers = JsonConvert.DeserializeObject<Users>(content);
    
                //As we have to return IAction Type So converting to IAction Class Using OkObjectResult We Even Can Use OkResult
                var result = new OkObjectResult(objUsers);
                return (IActionResult)result;
            }
