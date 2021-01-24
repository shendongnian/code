    private readonly RequestDelegate _next;
    private readonly IUserSession _userSession;
    private readonly ISessionServices _sessionServices;
    public ConfigureSessionMiddleware(RequestDelegate next, IUserSession userSession, ISessionServices sessionServices)
    {
        _next = next;
        _userSession = userSession;
        _sessionServices = sessionServices;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        //rest of your code
    }
