        public class ExpiredTokenMiddleware
    	{
    		private readonly RequestDelegate _next;
    
    		public ExpiredTokenMiddleware(RequestDelegate next)
    		{
    			_next = next;
    		}
    
    		public async Task Invoke(HttpContext context)
    		{
    			if (context.Response.Headers["Token-Expired"] == "True")
    			{
    				context.Response.StatusCode = 200;
    
    				// DO NOT CALL NEXT. THIS SHORTCIRCUITS THE PIPELINE
    			}
    			else
    			{
    				await _next(context);
    			}
    		}
    	}
