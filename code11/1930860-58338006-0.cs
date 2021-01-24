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
                    var controller = routeData.RouteValues["controller"]?.ToString();
                    var action = routeData.RouteValues["action"]?.ToString();
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
