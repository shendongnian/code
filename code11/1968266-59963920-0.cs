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
