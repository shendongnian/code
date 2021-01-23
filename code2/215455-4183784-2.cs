    public static bool IsAccountMemberOfGroup2(PrincipalContext ctx, string account, string groupName)
    {
       bool found = false; 
       GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, groupName);
       if (group != null)
       {
          found = group.GetMembers()
                     .Any(m => string.Compare(m.DistinguishedName, account, true) == 0);
       }
       return found;
    }
