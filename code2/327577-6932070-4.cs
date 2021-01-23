    public class AuthorizeByRightAttribute : AuthorizeAttribute
        {
           protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
            {
                var authorized = base.AuthorizeCore(httpContext);
                if (authorized && controller != null)
                {
                    //Return true or false based on some criteria
                }
                    
            }
