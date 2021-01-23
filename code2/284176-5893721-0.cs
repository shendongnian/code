        public static string GetEmail(string userId)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal group = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userId);
            return group.EmailAddress;
        }
