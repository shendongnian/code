    public static void Main(string[] args)
    {
        var input = new List<int> {100, 101, 102, 103, 110, 111, 112, 130, 131, 132};
        var output = RemoveSequential(input, 3);
        Console.WriteLine($"Input:  {string.Join(", ", input)}");
        Console.WriteLine($"Output: {string.Join(", ", output)}");
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
