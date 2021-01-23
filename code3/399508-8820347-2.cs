    try
    {
      PrincipalContext computerContext = new PrincipalContext(ContextType.Machine);
    
      /* Retreive a user
       */
      UserPrincipal user = UserPrincipal.FindByIdentity(computerContext, "utilisateur1");
      if (user != null)
        user.Delete();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
    Console.WriteLine("Done!");
