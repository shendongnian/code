    public static string RemovePuncutation(string input)
    {
        var punctuation = new[] {'!', '\'', ',', '.'};
        return string.Concat(input.Where(chr => !punctuation.Contains(chr)));
    }
    private static void Main()
    {
        var words = new[] {"dog", "cat", "bird"};
        // Notice the period after dog...
        var input = "The quick brown fox jumps over the lazy dog.";
        var wordcount = input.Split(' ')
            .Count(word => words.Contains(RemovePuncutation(word).ToLower()));
    }
