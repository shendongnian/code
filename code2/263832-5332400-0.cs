    using System.DirectoryServices.AccountManagement;
    public List<GroupPrincipal> GetGroupsForUser(string username)
    {
      List<GroupPrincipal> result = new List<GroupPrincipal>();
      // set up domain context - if you do a lot of requests, you might
      // want to create that outside the method and pass it in as a parameter
      PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
      // find user by name
      UserPrincipal user = UserPrincipal.FindByIdentity(username);
  
      // get the user's groups
      if(user != null)
      {
         foreach(GroupPrincipal gp in user.GetAuthorizationGroups())
         {
             result.Add(gp);
         }    
      }
      return result;
    }
