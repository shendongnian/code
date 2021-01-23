    public class MustHaveFooAccessAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // Do necessary tests here
        }
    }
