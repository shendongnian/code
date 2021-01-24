    [FunctionName("Function1")]
    		public async Task<HttpResponseMessage> Run(
    			[HttpTrigger(AuthorizationLevel.Anonymous,"post", Route = null)]
    			HttpRequestMessage req,
    			ILogger log)
    		{
    			log.LogInformation("C# HTTP trigger function processed a request.");
    
    			var context = (DefaultHttpContext) req.Properties["HttpContext"];
    			var host = context.Request.Host;
    			log.LogInformation(host.ToString());
    			return req.CreateResponse(HttpStatusCode.Accepted);
    
    		}
