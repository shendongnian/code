    Console.Write("User: ");
    var name = Console.ReadLine().Trim();
    PrincipalContext context = new PrincipalContext(ContextType.Machine);
    UserPrincipal user = UserPrincipal.FindByIdentity(context, name);
    if (user == null)
        Console.WriteLine("{0} not found", name);
    else
    {
        Console.WriteLine("Name: {0}", user.Name);
        Console.WriteLine("DisplayName: {0}", user.DisplayName);
    }
    Console.Write("Press any key to continue . . . ");
    Console.ReadKey(true);
    Console.WriteLine();
