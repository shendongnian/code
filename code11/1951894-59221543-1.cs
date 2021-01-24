    public static void Main(string[] args)
    {
        var trans = new Transformer();
        var items = new[] { 1, 2, 1, 0, 3 };
        // Add a bunch of inputs at once:
        trans.Add(items);
        // Display results
        Console.WriteLine($"After adding 5 items: {trans}");
        // Add a single item
        trans.Add(2);
        // Display results
        Console.WriteLine($"After adding 1 more item: {trans}");
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
