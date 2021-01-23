        public static string GetEmail(string userId)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userId);
            return user.EmailAddress;
        }
