    var ctx = new PrincipalContext(ContextType.Domain, null);
    using (var up = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, "MyName"))
    {
        Console.WriteLine(up.DistinguishedName);
        Console.WriteLine(up.SamAccountName);
        // Print groups that this user is a member of
        foreach (var group in up.GetGroups())
        {
            Console.WriteLine(group.SamAccountName);
        }
    }
    
