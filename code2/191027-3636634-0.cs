    static void Main(string[] args)
    {
        var sb = new StringBuilder();
        sb.AppendLine("this");
        sb.AppendLine("is");
        sb.AppendLine("test");
        // StringSplitOptions.None counts the last (blank) newline 
        // which the last AppendLine call creates
        // if you don't want this, then replace with 
        // StringSplitOptions.RemoveEmptyEntries
        var lines = sb.ToString().Split(
            new string[] { 
                System.Environment.NewLine }, 
            StringSplitOptions.None).Length;
        Console.WriteLine("Number of lines: " + lines);
        Console.WriteLine("Press enter to exit.");
        Console.ReadLine();
    }
