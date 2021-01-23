    public static void Main(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            Console.WriteLine("Please specify a filename as a parameter.");
            return;
        }
        var fileContents = File.ReadAllText(args[0]);
        // ... do something with the file contents
    }
