csharp
public class GlobalVerbRoleRequirement: IAuthorizationRequirement
{
    public bool IsAllowed(string role, string verb)
    {
        // allow all verbs if user is "admin"
        if(string.Equals("admin", role, StringComparison.OrdinalIgnoreCase)) return true;
        // allow the "GET" verb if user is "support"
        if(string.Equals("support", role, StringComparison.OrdinalIgnoreCase) && string.Equals("GET",verb, StringComparison.OrdinalIgnoreCase)){
            return true;
        };
        // ... add other rules as you like
        return false;
    }
}
(You might want to custom the `IsAllowed(role, verb)` further if you have more rules)
And tell ASP.NET Core how to handle this rules with an AuthorizationHandler:
public class GlobalVerbRoleHandler : AuthorizationHandler<GlobalVerbRoleRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public GlobalVerbRoleHandler(IHttpContextAccessor httpContextAccessor)
    {
        this._httpContextAccessor = httpContextAccessor;
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GlobalVerbRoleRequirement requirement)
    {
        // check whether the user has required roles for current verb
        var roles = context.User.FindAll(c => string.Equals(c.Type,ClaimTypes.Role)).Select(c => c.Value);
        var verb= _httpContextAccessor.HttpContext?.Request.Method;
        if(string.IsNullOrEmpty(verb)){ throw new Exception($"request cann't be null!"); }
        foreach(var role in roles){
            if(requirement.IsAllowed(role,verb)){
                context.Succeed(requirement); 
                return Task.CompletedTask;
            }
        }
        context.Fail();
        return Task.CompletedTask;
    }
}
Finally, don't forget to register the related services in the startup:
csharp
services.AddHttpContextAccessor();
services.AddScoped<IAuthorizationHandler, GlobalVerbRoleHandler>();
services.AddAuthorization(opts =>{
    opts.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddRequirements(new GlobalVerbRoleRequirement())
        .Build();
});
Now every `[Authorize]` will also check the *Role* against the current HTTP *Verb* automatically.
[Authorize]
public class WorkController : ControllerBase
{
   
    [HttpPost("something/add")]
    public async Task<IActionResult> Add()
    {
        //add
    }
    [HttpGet("something/get")]
    public async Task<IActionResult> Get()
    {
        //get
    }
}
