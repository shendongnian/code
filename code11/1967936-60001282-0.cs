    public class SetGuidMiddleware
    {
    	private readonly RequestDelegate _next
    
    	public SetGuidMiddleware(RequestDelegate next)
    	{
    		_next = next;
    	}
    
    	public async Task Invoke(HttpContext context)
    	{
    		if (!HttpMethods.IsGet(context.Request.Method)
    		   && !HttpMethods.IsHead(context.Request.Method)
    		   && !HttpMethods.IsDelete(context.Request.Method)
    		   && !HttpMethods.IsTrace(context.Request.Method)
    		   && context.Request.ContentLength > 0)
    		{
    			//This line allows us to set the reader for the request back at the beginning of its stream.
    			context.Request.EnableRewind();
    
    			var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
    			await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
    			var bodyAsText = Encoding.UTF8.GetString(buffer);
    
    			var secondRequest = JObject.Parse(bodyAsText);
    			secondRequest["token"] = "test";
    			secondRequest["newId"] = Guid.NewGuid();
    
    			var requestContent = new StringContent(secondRequest.ToString(), Encoding.UTF8, "application/json");
    			context.Request.Body = await requestContent.ReadAsStreamAsync();
    		}
    
    		await _next(context);
    	}
    }
