    string groupName = "Domain Users";
    string domainName = "your domainName";
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
    GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);
    if (grp != null)
    {
         foreach (Principal p in grp.GetMembers(false))
            {
                p.DisplayName //do your action here
            }
 
 
        grp.Dispose();
        ctx.Dispose();
    }
