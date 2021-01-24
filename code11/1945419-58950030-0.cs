       public class CustomModuleAuthorization : System.Web.Mvc.AuthorizeAttribute
        {
            public string NomModule { get; set; }
            private string _reason = "";
    
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
    
                //return base.AuthorizeCore(httpContext);
                string json;
                ModulesModel module = null;
    
                try
                {
                    //Appel de l'API pour vérification que le user à acces au module renseigné
                    var windowsIdentity = System.Web.HttpContext.Current.Request.LogonUserIdentity as System.Security.Principal.WindowsIdentity;
    
                    if (windowsIdentity == null)
                    {
                        _reason = "Identity not a valid windows identity. ";
                        return false;
                    }
    
                    using (windowsIdentity.Impersonate())
                    {
                        using (var client = new System.Net.WebClient { UseDefaultCredentials = true })
                        {
                            string fullUri = ConfigurationManager.AppSettings["UrlApiSuma"].ToString();
    
                            client.Headers.Add("Content-Type:application/json; charset=utf-8");
                            client.Headers.Add("Accept:application/json");
                            client.Headers.Add("SessionID", Guid.NewGuid().ToString());
    
                            json = client.DownloadString(fullUri);
                            module = JsonConvert.DeserializeObject<ModulesModel>(json);
    
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    _reason = e.Message;
                    return false;
                }
            }
    
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Error",
                            action = "UnAuthorizedAccess",
                            module= NomModule,
                            message = _reason
                        })
                    );
    
    
            }
    
        }
