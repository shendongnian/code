    private static string CreateSessionId(HttpContext httpContext)
    {
        var manager = new SessionIDManager();
        string newSessionId = manager.CreateSessionID(httpContext);
        return newSessionId;
    }
    public static void SetSessionId(HttpContext httpContext, string newSessionId, string redirect)
    {
        var manager = new SessionIDManager();
        bool redirected;
        bool cookieAdded;
        manager.SaveSessionID(httpContext, newSessionId, out redirected, out cookieAdded);
        // Just write anything to the session, so it isn't abandoned
        httpContext.Session["WriteAnythingToTheSession"] = "Ok boss, consider it done!";
        httpContext.Response.Redirect(redirect, true);
    }
