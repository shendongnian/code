    public class MustHaveFooAccessAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Return true or false after checking authorization
        }
    }
