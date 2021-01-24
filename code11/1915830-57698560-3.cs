    // First change name to represent what you actually wanna do
    public static string GetRandomParagraph(string fileName)
    {
        /* 
           Rather than reading all the lines, read all the text
           this gives you the ability to split by paragraph
        */
        var allText = File.ReadAllText(fileName);
        // Split the text into paragraphs
        var paragraphs = allText.Split($"{Environment.NewLine}{Environment.NewLine}");
        // Get a random index between 0 and the amount of paragraphs
        var randomParagraph = GetRandom(paragraphs.Length);
        return paragraphs[randomParagraph];
    }
    // A stronger random value
    public static int GetRandom(int limit)
    {
        int value;
        // use crypto provider to get a seed for the random class
        using (var cryptoProvider = new RNGCryptoServiceProvider())
        {
            var random = new Random(cryptoProvider.GetHashCode());
            value = random.Next(0, limit);
        }
        return value;
    }
