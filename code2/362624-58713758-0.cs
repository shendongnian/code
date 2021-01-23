    public bool IsMember(string groupName, string samAccountName)
    {
        using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
        using (UserPrincipal user = UserPrincipal.FindByIdentity(context, samAccountName))
        using(GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupName))
        {
            return group.GetMembers(true).OfType<Principal>().Any(u => u.SamAccountName.Equals(user.SamAccountName, StringComparison.InvariantCultureIgnoreCase));
        }
       
    }
