     public enum Role {
	   Admin,
	   User
      }    
     public class AuthorizeRolesAttribute : AuthorizeAttribute {
       private Role[] _roles;
       public AuthorizeRolesAttribute(params Role[] roles) {
          _roles = roles;
       }
       protected override bool IsAuthorized(HttpActionContext actionContext) {
        return _roles.Contains(Globals.CurrentUser.Role);
       }
    }
