    static void Main(string[] args)
    {
        string validString = "Hello World";
        string invalidString = "Hello (World)";
    
        Console.WriteLine($"{validString} --> {validString.IsValid()}");
        Console.WriteLine($"{invalidString} --> {invalidString.IsValid()}");
    }
