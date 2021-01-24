using System;
using System.Diagnostics;
using System.Web.Http;
using System.Web;
using System.Web.Http.Controllers;
namespace myAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizeCustomAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Check against a list of admins
            if (Authentication.IsAdmin(HttpContext.Current.User.Identity.Name) || Authentication.IsAdmin( HttpContext.Current.Request.LogonUserIdentity.Name ))
            {
                if(HttpContext.Current.User.Identity.IsAuthenticated || HttpContext.Current.Request.LogonUserIdentity.IsAuthenticated )
                {
                    Debug.WriteLine("USER IS AUTHORIZED");
                } else
                {
                    Debug.WriteLine("USER IS AN ADMIN BUT IS UNAUTHENTICATED");
                    HandleUnauthorizedRequest(actionContext); // redirect to get authenticated
                }
                
            }
            else
            {
                Debug.WriteLine("USER IS NOT AN ADMIN AND IS DENIED");
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK); // return a blank response
            }
        }
    }
}
