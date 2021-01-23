    try
    {
      PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, "WM2008R2ENT:389", "dc=dom,dc=fr", "jpb", "pwd");
    
      /* Retreive a user
       */
      UserPrincipal user = UserPrincipal.FindByIdentity(domainContext, "user3");
      if (user != null)
        user.Delete();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
    Console.WriteLine("Done!");
