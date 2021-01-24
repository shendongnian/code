switch(shape)
{
    case Circle c:
        WriteLine($"circle with radius {c.Radius}");
        break;
    case Rectangle s when (s.Length == s.Height):
        WriteLine($"{s.Length} x {s.Height} square");
        break;
    case Rectangle r:
        WriteLine($"{r.Length} x {r.Height} rectangle");
        break;
    default:
        WriteLine("<unknown shape>");
        break;
    case null:
        throw new ArgumentNullException(nameof(shape));
}
So in your case
switch (value)
{
     case "taikun project list":
        await Project.GetProjects();
        break;
     case String s when s.StartsWith("taikun project create"):
        Console.WriteLine("Please specify project name");
        string name = Console.ReadLine();
        Console.WriteLine("Please specify project kubespray version");
        string kube = Console.ReadLine();
        await Project.Create(name,kube);
        break;                   
     default:
        Console.WriteLine("Please specify valid command");
        break;
}
  [1]: https://blogs.msdn.microsoft.com/dotnet/2016/08/24/whats-new-in-csharp-7-0/
