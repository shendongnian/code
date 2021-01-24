[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class EnvironmentSpecificAutorizeAttribute : AuthorizeAttribute
{
    public string AllowAnonymousEnvironment { get; set; }
    protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
    {
        // if currentEnv == AllowAnonymousEnvironment 
        //    return 
        // else
        //    base.HandleUnauthorizedRequest(actionContext);
    }
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        // same logic as above
        base.OnAuthorization(actionContext);
    }
    public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
    {
        // same logic as above
        return base.OnAuthorizationAsync(actionContext, cancellationToken);
    }
}
You may find other suggestions in [this thread](https://stackoverflow.com/questions/41577389/net-core-api-conditional-authentication-attributes-for-development-production)
