    static void Main(string[] args)
    {
        var type = typeof(DemoClass);
        var members = type.GetMembers();
        var flags = BindingFlags.Public | BindingFlags.Instance;
        Console.WriteLine($"{type.Name} members with flags containing: {flags}\n");
        foreach (var m in members.Where(m => m.GetFlags().Contains(flags)))
            Print(m);
        flags = BindingFlags.Public | BindingFlags.Static;
        Console.WriteLine($"\n{type.Name} members with flags matching exactly: {flags}\n");
        foreach (var m in members.Where(m => m.GetFlags().MatchesExactly(flags)))
            Print(m);
        flags = BindingFlags.NonPublic | BindingFlags.Instance;
        Console.WriteLine($"\n{type.Name} members with flags matching partly: {flags}\n");
        foreach (var m in members.Where(m => m.GetFlags().MatchesPartly(flags)))
            Print(m);
    }
    private static void Print(MemberInfo memberInfo) =>
        Console.WriteLine($"\t{memberInfo.GetType().Name} {memberInfo} - {memberInfo.GetFlags()}");
