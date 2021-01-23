    public void Foo(string realArg, int anotherRealArg, params int[] variableArgs)
    {
        Console.WriteLine("My real string argument was " + realArg);
        Console.WriteLine("My real integer argument was " + anotherRealArg);
        Console.WriteLine("And I was given " + variableArgs.Length + " extra arguments");
    }
    // Usage
    Foo("Bar", 1, 2, 3, 4, 5);
