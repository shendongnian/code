    public static void Main(string[] args)
    {
        var items = new List<int> {1, 1, 1, 3, 3, 4, 4, 1, 1, 8, 8, 8, 5, 6, 7, 7, 7, 7, 8, 8};
        // Get our item counts and output them to the console window
        GetItemCounts(items).ForEach(Console.WriteLine);
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
