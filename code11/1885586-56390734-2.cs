    public class CustomeAuthorizeAttribute : AuthorizeAttribute
    {
        
         public override void OnAuthorization(AuthorizationContextfilterContext)          
        {
             if (!isUserExistInHrm)
    		{
                TempData["UserisNotExistInInExternalApi"] = "Wrong credentials.";
                return RedirectToAction("AccountLogin");
    		}
    		else
    		{
                FormsAuthentication.SetAuthCookie(authModel.UserName, false);
    		}
        }
    }
