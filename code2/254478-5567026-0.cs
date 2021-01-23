    static void Main(string[] args)
    {
        Console.WriteLine("Enter the string:");
        string[] words = Console.ReadLine().Split(' ');
        var longestWords = words
            .Where(w => w.Length == words.Max(m => m.Length));
        Console.WriteLine("Longest words are: {0}", 
            string.Join(", ", longestWords.ToArray()));
    }
