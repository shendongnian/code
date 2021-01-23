    try
    {
      PrincipalContext context = new PrincipalContext(ContextType.Domain, "WM2008R2ENT:389", "dc=dom,dc=fr", "jpb", "passwd");
    
      /* Retreive a user principal
       */
      UserPrincipal user = UserPrincipal.FindByIdentity(context, "user1");
    
      /* Retreive a group principal
       */
      GroupPrincipal adminGroup = GroupPrincipal.FindByIdentity(context, @"dom\Administrateurs");
    
      foreach (Principal p in adminGroup.Members)
      {
        Console.WriteLine(p.Name);
      }
    
      adminGroup.Members.Remove(user);
      adminGroup.Save();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
