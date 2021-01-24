    public class MyAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // ...
            // if (HttpContext.Current.User == null || HttpContext.Current.User.Identity == null || !HttpContext.Current.User.Identity.IsAuthenticated)
                // throw new Exception("Not logged in");
        }
    }
    [MyAuthorize]
    public bool DoSomthing()
    {
        ...
    }
