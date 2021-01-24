    public class MyMiddleware 
    {
       private readonly RequestDelegate next;
       public MyMiddleware (RequestDelegate next)
       {
            this.next = next;
       }
       public async Task Invoke(HttpContext ctx) 
       {
           // Your check here, something like
           if (!ctx.User.Claims.TryGetClaim("merchant_id", out long merchantId))
           {
                ctx.Response.StatusCode = 400;
           }
           else
           {
                await next.Invoke(ctx);
           }
           
       }
    }
