    public static string HideAllButFirstAndLast(string word)
    {
        if (word == null) return null;
        if (word.Length < 4) return new string('*', word.Length);
        return word[0] + new string('*', word.Length - 2) + word[word.Length - 1];
    }
    private static void Main()
    {
        Console.WriteLine("Enter a sentence: ");
        var sentence = Console.ReadLine();
        Console.WriteLine("Enter a comma-separated list of censored words:");
        var censoredWords = Console.ReadLine()
            .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
            .Select(word => word.Trim())
            .ToList();
        // Split sentence into words, replace words as needed, and join the words again
        sentence = string.Join(" ", sentence.Split().Select(word =>
            censoredWords.Contains(word) ? HideAllButFirstAndLast(word) : word));
        Console.WriteLine(sentence);
        GetKeyFromUser("\n\nDone! Press any key to exit...");
    }
