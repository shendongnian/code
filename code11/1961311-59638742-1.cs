    public static void Main()
    {
        var args = "one two \"three four\" five \"six seven\" eight \"nine ten";
        Console.WriteLine($"Command line: \"{args}\"\n");
        Console.WriteLine("Individual Arguments");
        Console.WriteLine("--------------------");
        Console.WriteLine(string.Join(Environment.NewLine, ParseCommandLine(args)));
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
