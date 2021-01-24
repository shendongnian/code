    static void Main(string[] args)
    {
        string[] inputs = new string[] {
            null,
            string.Empty,
            "A",
            "ASDF-123-ZXCV-456",
            "YUIO-123-BNNM-987",
            "QWER-123-LKJH-111",
            "A1234",
            "A456"
        };
        const int longestInputLength = 17;
            
        foreach (string input in inputs)
        {
            bool result = IsNonNegativeIntegerWithPrefix(input);
            Console.WriteLine($"{input,longestInputLength}: {result}");
        }
    }
    static bool IsNonNegativeIntegerWithPrefix(string text)
    {
        const string prefix = "A";
        if (text == null)
        {
            // Alternative: throw new ArgumentNullException(nameof(text));
            return false;
        }
        // There must be at least one additional character beyond the prefix
        if (text.Length < prefix.Length + 1)
            return false;
        // The string must start with the prefix
        if (!text.StartsWith(prefix))
            return false;
        // Every character after the prefix must be a digit
        for (int index = prefix.Length; index < text.Length; index++)
            if (!char.IsDigit(text[index]))
                return false;
        return true;
    }
