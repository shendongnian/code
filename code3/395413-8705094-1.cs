    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain,"DomainName");
    // find the group in question
    GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "YourGroupNameHere");
  
    // if found....
    if (group != null)
    {
       // iterate over members
       foreach (Principal p in group.GetMembers())
       {
          Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
          // do whatever you need to do to those members
       }
    }
