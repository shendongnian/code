    public static string WrapEachElementWith
        (   string input, 
            params Func<string, string>[] func )
    {
        foreach (var f in func.Reverse())
            input = f(input);
        return input;
    }
