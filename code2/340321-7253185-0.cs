    static void Main(string[] args)
    {
        string groupName = "Domain Users";
        string domainName = "";
     
        PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
        GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);
     
        if (grp != null)
        {
             foreach (Principal p in grp.GetMembers(false))
                {
                    Console.WriteLine(p.SamAccountName + " - " + p.DisplayName);
                }
     
     
            grp.Dispose();
            ctx.Dispose();
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\nWe did not find that group in that domain, perhaps the group resides in a different domain?");
            Console.ReadLine();
        }
    }
