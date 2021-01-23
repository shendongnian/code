    // return manager for a given user
    public UserPrincipal GetManager(PrincipalContext ctx, UserPrincipal user)
    {
        UserPrincipal result = null;
        if (user != null)
        {
            // get the DirectoryEntry behind the UserPrincipal object
            DirectoryEntry dirEntryForUser = user.GetUnderlyingObject() as DirectoryEntry;
            if (dirEntryForUser != null)
            {
                 // check to see if we have a manager name - if so, grab it
                 if (dirEntryForUser.Properties["manager"] != null)
                 {
                     string managerDN = dirEntryForUser.Properties["manager"][0].ToString();
                     // find the manager UserPrincipal via the managerDN 
                     result = UserPrincipal.FindByIdentity(ctx, managerDN);
                 }
            }
        }
        return result;
    }
