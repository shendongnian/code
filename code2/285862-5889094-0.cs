    static void Main(string[] args)
    {
        var test = "Line1\\nLine2";
        // Line1\nLine2
        Console.WriteLine(test);
        // Line1
        // Line2
        Console.WriteLine(test.Replace("\\n", Environment.NewLine));
    
        Console.ReadKey();
    }
