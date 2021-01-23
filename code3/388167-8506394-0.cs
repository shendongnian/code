    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    // find a user
    UserPrincipal user = UserPrincipal.Current; // this would be John Smith
    
    if(user != null)
    {
       // get the user's groups he's a member of
       PrincipalSearchResult<Principal> results = user.GetAuthorizationGroups();
       
       // now you just need to iterate over the groups and see if you find the
       // one group you're interested in
    }
 
