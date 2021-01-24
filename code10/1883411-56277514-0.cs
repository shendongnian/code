     public class WebApiAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext ctx)
        {
            //unauthorized code here
        }
        //or
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
           //is authorized
        }
    }
