    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    // find the computer in question
    ComputerPrincipal computer = ComputerPrincipal.FindByIdentity(ctx, "NAME");
    // if found - delete it
    if (computer != null)
    {
       computer.Delete();
    }
            
