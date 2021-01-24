    public string ResetPassword(LoginDTO model) {
      try {
        //get context by admin user
    
        PrincipalContext ctx = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["ONLINE-AD"], WebConfigurationManager.AppSettings["AdminName"], WebConfigurationManager.AppSettings["AdminPassword"]);
    
        //find the wanted user
        var user = UserPrincipal.FindByIdentity(ctx, model.UserName);
    
        if (user != null) {
          try {
            user.ChangePassword(model.Password, model.NewPassword);
          } catch {
            return "-1";
          }
    
        }
    
      } catch (Exception ex) {
        return "-1";
      }
      return "1"
    }
