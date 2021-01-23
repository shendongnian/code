    ...
    static int Main(String[] args)
    {
    ...
    #if !DEBUG
        Console.SetOut(TextWriter.Null);
        Console.SetError(TextWriter.Null);
    #endif
    ...
    }
