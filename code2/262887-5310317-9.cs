    public List<GroupPrincipal> GetGroups(string userName)
    {
       List<GroupPrincipal> result = new List<GroupPrincipal>();
  
       // establish domain context
       PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);
       // find your user
       UserPrincipal user = UserPrincipal.FindByIdentity(yourDomain, userName);
       // if found - grab its groups
       if(user != null)
       {
          PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups();
          // iterate over all groups
          foreach(Principal p in groups)
          {
             // make sure to add only group principals
             if(p is GroupPrincipal)
             {
                 result.Add((GroupPrincipal)p);
             }
          }
       }
       return result;
    }
