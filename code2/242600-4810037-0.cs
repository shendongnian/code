    public UserPrincipal GetUserPrincipal(string userName)
        {            
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, LDAPDomain, LDAPUser, LDAPPassword);                     
            return UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userName);            
        }
