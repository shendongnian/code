    [ExecuteMe]
    public void CallM3()
    {
        M3("Hello", "reflection");
    }
    public void M3(params object[] args)
    {
        var strings = args.Where(arg => arg != null).Select(arg => arg.ToString());
        Console.WriteLine(string.Join(", ", strings));
    }
