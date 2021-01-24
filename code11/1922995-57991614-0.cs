    public class Function1
    	{
    		private readonly IClass1 _class1;
    		public Function1(IClass1 class1)
    		{
    			_class1 = class1;
    		}
    		[FunctionName("Function1")]
    		public async Task<HttpResponseMessage> Run(
    			[HttpTrigger(AuthorizationLevel.Anonymous,"post", Route = null)]
    			HttpRequestMessage req,
    			ILogger log)
    		{
    			log.LogInformation("C# HTTP trigger function processed a request.");
    			return req.CreateResponse(HttpStatusCode.Accepted);
    
    		}
    	}
