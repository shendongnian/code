    /// <summary>
    /// Checks if a user in is a active directory group.
    /// <summary>
    /// <param name="username">Can contain the domain and username or just username
    ///    (eg. domain\username or username).  If no domain is specified, the default
    ///    domain is used.</param>
    /// <param name="group">Active directory group to check.  Group name only.  No
    ///    leading domain as the domain from the user is used.</param>
    /// <returns></returns>
    public bool UserIsInActiveDirectoryGroup(string username, string group)
    {
        bool isInGroup = false;
        string user = "";
        string domain = "";
        // Parses off domain and user to seperate values
        ParseUserDomain(username, out domain, out user);   
    
        if (string.IsNullOrEmpty(user) ||
            string.IsNullOrEmpty(domain) ||
            string.IsNullOrEmpty(group))
        {
            return false;
        }
        using (PrincipalContext ADContext = new PrincipalContext(ContextType.Domain,
            domain))
        {
            using (GroupPrincipal principalGroup = 
                GroupPrincipal.FindByIdentity(ADContext, group))
            {
                if (principalGroup != null)
                {
                    using (UserPrincipal ADPrincipalUser = 
                        UserPrincipal.FindByIdentity(ADContext, user))
                    {
                        // True means deep search
                        var users = principalGroup.GetMembers(true);
                        isInGroup = users.Contains(ADPrincipalUser);
                    }
                }
            }
        }
        return isInGroup;
    }
