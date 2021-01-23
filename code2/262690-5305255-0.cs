    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "yourdomain.com"))
    {
        using (UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "YourUser"))
        {
            foreach (Principal p in user.GetGroups())
            {
                 Console.WriteLine(p.Name);
            }
        }
     }
