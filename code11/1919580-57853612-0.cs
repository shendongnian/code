 lang-c#
public class MyFilter : IAuthorizationFilter
{
    //
    public MyFilter()
    {
        //
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.User.Identity.IsAuthenticated)
        {
            var hasPermission= ... ;
            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
        else
        {
            context.Result = new RedirectResult("/Accounts/Login");
        }
    }
}
