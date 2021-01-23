    IsUserMemberOf("domain1\\username","domain2\\groupname")
    static bool IsUserMemberOf(string userName, string groupName)
    {
     using (var ctx = new PrincipalContext(ContextType.Domain,"domain1"))
     using (var groupPrincipal = GroupPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain,"domain2"), groupName))
     using (var userPrincipal = UserPrincipal.FindByIdentity(ctx, userName))
     {
        return userPrincipal.IsMemberOf(groupPrincipal);
     }
} 
