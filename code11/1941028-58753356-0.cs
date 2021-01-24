    public class Function1
    {
    	private readonly ILogger _logger;
    
    	public Function1(ILogger<Function1> logger)
    	{
    		_logger = logger;
    	}
    
    	[FunctionName("Function1")]
    	public async Task<IActionResult> Run(
    		[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
    	{
    		_logger.LogInformation("C# HTTP trigger function processed a request.");
    
    		string name = req.Query["name"];
    
    		string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    		dynamic data = JsonConvert.DeserializeObject(requestBody);
    		name = name ?? data?.name;
    
    		return name != null
    			? (ActionResult)new OkObjectResult($"Hello, {name}")
    			: new BadRequestObjectResult("Please pass a name on the query string or in the request body");
    	}
    }
