    public void CheckUserExist(string login)
    {
      using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain))
      {
        var user = UserPrincipal.FindByIdentity(principalContext, login);
        if (user == null)
        { 
          this.UserMessageText = "xx"; 
        }
      }
    }
