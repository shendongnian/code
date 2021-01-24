    private readonly HttpContext _context;
    public MyType(IHttpContextAccessor accessor)
    {
        _context = accessor.HttpContext;
    }
    public void CheckAdmin()
    {
        if (!_context.User.IsInRole("admin"))
        {
            throw new UnauthorizedAccessException("The current user isn't an admin");
        }
    }
> ✅ GOOD This example stores the IHttpContextAccesor itself in a field and uses the HttpContext field at the correct time (checking for null).
    private readonly IHttpContextAccessor _accessor;
    public MyType(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
    public void CheckAdmin()
    {
        var context = _accessor.HttpContext;
        if (context != null && !context.User.IsInRole("admin"))
        {
            throw new UnauthorizedAccessException("The current user isn't an admin");
        }
    }
**Use a Scoped service instead**
Since a Singleton can't know what session to use. One option is to simply convert that service to a Scoped service. In ASP.NET Core, a request defines a scope. That's how controller actions and pipeline middleware get access to the correct HttpContext for each request.
Assuming the service is used by an action or middleware, perhaps the only change needed is to replace `AddSingleton<ThatService>` with `AddScoped<ThatService>`
**Turning the tables, or Inversion of Control**
Another option is for *callers* of that singleton should provide the session to it. Instead of using a cached session eg  :
    public void SetStatus(string status)
    {
        _session.SetString(SessionKeys.UserStatus, "some value");
    }
Ask for the session or HttpContext as a parameter :
    public void SetStatus(string status,ISession session)
    {
        session.SetString(SessionKeys.UserStatus, "some value");
    }
And have callers pass the correct session to it
