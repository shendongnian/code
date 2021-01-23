    using System.Web
    List<string> WhoIsAuthorized = new List<string>() {"ADGroup", "AdUser", "etc"};
    public class MyController : ApiController
    public MyController() {
     #if TEST 
        var myPrincipal = new WindowsPrincipal(new WindowsIdentity("testuser@contoso.com"));
        System.Threading.Thread.CurrentPrincipal = myPrincipal;
        HttpContext.Current.User = myPrincipal;
     #endif
    }
    public HttpResponseMessage MyAction() {
       var userRoles = Roles.GetRolesForUser(User.Identity.Name);
       bool isAuthorized = userRoles.Any(role => WhoIsAuthorized.Contains(role));
    }
