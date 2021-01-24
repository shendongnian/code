public class CustomAuthorizationHandler: IAuthorizationHandler
{
   public Task HandleAsync(AuthorizationHandlerContext context)
   {
       var authFilterCtx = (Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)context.Resource;
       string authHeader = authFilterCtx.HttpContext.Request.Headers["Authorization"];
       if (authHeader != null && authHeader.Contains("Bearer"))
       {
          var token = authHeader.Replace("Bearer", "");
          // Now token can be used for further authorization
       }
            
       throw new NotImplementedException();
    }
}
Lastly registering the handler in `Startup.cs`
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IAuthorizationHandler, CustomAuthorizationHandler>();
}
