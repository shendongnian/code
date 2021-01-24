csharp
public class MembershipResourceFilter : IAsyncResourceFilter
{
    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        var HttpContext = context.HttpContext;
        var authZ = HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
        var routeData= context.RouteData;
        var result = await authZ.AuthorizeAsync(HttpContext.User, routeData,"premium membership");
        if(!result.Succeeded)
        {
            context.Result = new RedirectToActionResult("Upgrade", "Subscription", new { ReturnUrl = HttpContext.Request.Path });
        }
        await next();
    }
}
I test the above code with the following policy, it works fine for me.
csharp
services.AddAuthorization(o =>{
    o.AddPolicy("premium membership", pb => pb
        .RequireAuthenticatedUser()
        .RequireAssertion((context)=>{
            // check current context.User has premium membership
            var user = context.User;
            var routeData = context.Resource as RouteData;
            if(routeData != null){
                try{
                    var controller = routeData.Values["controller"]?.ToString();
                    var action = routeData.Values["action"]?.ToString();
                    // now you get the route value
                    if(controller == "Home" && action == "Action"){
                        // ...
                        return true;
                    }
                }catch{
                    return false;
                }
            }
            return false;
        })
    );
});
----------
**[Edit]**
If You don't want to change the `[Authorize("Premium")]`, you can create a simple **middleware** instead of a Resource Filter:
    ...
    app.UseAuthentication();
    app.UseRouting();
    
    app.Use(async(ctx,next)=>{
        var ep= ctx.Features.Get<IEndpointFeature>()?.Endpoint;
        var authAttr = ep?.Metadata?.GetMetadata<AuthorizeAttribute>()
        if(authAttr!=null && authAttr.Policy == "premium membership"){
            var authService = ctx.RequestServices.GetRequiredService<IAuthorizationService>();
            var result = await authService.AuthorizeAsync(ctx.User, ctx.GetRouteData(),authAttr.Policy);
            if(!result.Succeeded)
            {
                var path = $"/Subscription/Upgrade?ReturnUrl={ctx.Request.Path}";
                ctx.Response.Redirect(path) ;
                return;
            }
        }
        await next();
    });
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>{ ... });
The middleware and the Resource Filter basically does the same thing : invoke the authorization service and redirect when need.
