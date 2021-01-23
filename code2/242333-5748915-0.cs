    // return manager for a given user
    public UserPrincipal GetManager(PrincipalContext ctx, UserPrincipal user) {
        if (user != null) {
            // get the DirectoryEntry behind the UserPrincipal object
            var dirEntryForUser = user.GetUnderlyingObject() as DirectoryEntry;
            if (dirEntryForUser != null) {
                // check to see if we have a manager name - if so, grab it
                if (dirEntryForUser.Properties["manager"] != null && dirEntryForUser.Properties["manager"].Count > 0) {
                    string managerDN = dirEntryForUser.Properties["manager"][0].ToString();
                    // find the manager UserPrincipal via the managerDN 
                    return UserPrincipal.FindByIdentity(ctx, managerDN);
                }
            }
        }
        return null;
    }
