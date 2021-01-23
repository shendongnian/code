    static void Main(string[] args)
    {
        var flags = BindingFlags.NonPublic | BindingFlags.Public |
                    BindingFlags.Instance  | BindingFlags.DeclaredOnly;
        foreach(var method in typeof(Test).GetMethods(flags))
             Console.WriteLine(method);
    }
