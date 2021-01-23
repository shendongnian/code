    static void Main()
    {
        var rx = new Regex(@"\b\w+\b", RegexOptions.Compiled);
        var sampleText = @"For my custom made chat screen i am using the code below for checking censored words. But i wonder can this code performance improved. Thank you.
    if (srMessageTemp.IndexOf("" censored1 "") != -1)
    return;
    if (srMessageTemp.IndexOf("" censored2 "") != -1)
    return;
    if (srMessageTemp.IndexOf("" censored3 "") != -1)
    return;
    C# 4.0 . actually list is a lot more long but i don't put here as it goes away.
    And now some accented letters àèéìòù and now some letters with unicode combinable diacritics ";
        HashSet<string> prohibitedWords = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) { "custom", "combinable", "away" };
        var words = rx.Matches(sampleText);
        foreach (Match word in words)
        {
            string str = word.Value;
            if (prohibitedWords.Contains(str))
            {
                Console.WriteLine("[CENSORED]");
            }
            else
            {
                Console.WriteLine(word);
            }
        }
    }
