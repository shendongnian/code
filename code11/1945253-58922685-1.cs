    public static void Main(string[] args)
    {
        var results = GetKVPs("{greeting}, {recipient}, this is {sender}.", "Hello, Dolly, this is Louis.");
        foreach (var kvp in results)
        {
            Console.WriteLine($"{kvp.Key} = {kvp.Value}");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
