    using System.DirectoryServices.AccountManagement;
    // create a machine-context (local machine)
    PrincipalContext ctx = new PrincipalContext(ContextType.Machine);
    UserPrincipal up = UserPrincipal.FindByIdentity(ctx, IdentityType.Sid, <YourSidHere>);
    if (up != null)
    {
        Console.WriteLine("You've found: {0}", up.DisplayName);
    }
    else
    {
        Console.WriteLine("ERROR: no one found");
    }
