 c#
public void OnAuthentication(AuthenticationContext filterContext)
{
    var currentContext = HttpContext.Current;
    // If this is a new Session cookie the user has either not logged in yet
    // , or the Session cookie expired and was replaced with a new one.
    if (currentContext.Session.IsNewSession)
    { 
        if (Authorization.IsAuthenticated) 
        {
            // If Session is new but they're authenticated it's because their session cookie 
            // expired, so log them out.
            currentContext.Request.GetOwinContext().Authentication.SignOut();
        }
        // Ensure there is a Session cookie so that it's not new on subsequent requests
        currentContext.Session["SessionStart"] = DateTime.Now;
        filterContext.Result = new HttpUnauthorizedResult();
    }
}
