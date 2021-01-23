    var pc = new PrincipalContext(ContextType.Machine);
    var up = new UserPrincipal(pc);
    var users = new PrincipalSearcher(up).FindAll();
    foreach (var u in users)
        Console.WriteLine(u.Name);
    Console.WriteLine();
    Console.Write("User: ");
    var name = Console.ReadLine().Trim();
    var user = UserPrincipal.FindByIdentity(pc, name);
    if (user == null)
        Console.WriteLine("{0} not found", name);
    else
    {
        Console.WriteLine("Name: {0}", user.Name);
        Console.WriteLine("DisplayName: {0}", user.DisplayName);
    }
