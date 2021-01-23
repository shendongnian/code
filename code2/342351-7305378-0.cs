    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
    {
        UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "your_login");
        foreach (var group in user.GetGroups())
        {
            Console.WriteLine(group.Name);
        }
    }
