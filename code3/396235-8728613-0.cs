    public List<GroupPrincipal> GetGroups(string userName)
    {
       List<GroupPrincipal> result = new List<GroupPrincipal>();
  
       // establish domain context
       PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);
       // find your user
       UserPrincipal user = UserPrincipal.FindByIdentity(yourDomain, username);
       // if found - grab its groups
       if(user != null)
       {
          PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups();
          // iterate over all groups
          foreach(Principal p in groups)
          {
             // make sure to add only group principals or change this to add to a list or varible if needed.
             if(p is GroupPrincipal)
             {
                 result.Add(p);
             }
          }
       }
       return result;
    }
