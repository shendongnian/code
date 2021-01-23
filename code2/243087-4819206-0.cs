    public class WebUser:System.Security.Principal.IPrincipal
    {
      ...
      public System.Security.Principal.IIdentity Identity{get; private set;}
      public WebUser(...)
      {
        HttpContext.Current.User = this;
      }
    }
    public class WebIdentity : System.Security.Principal.IIdentity
    {
      ...
    }
    
    public void Login(...)
    {
      var newUser = new WebUser(...);
    }
