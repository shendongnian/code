    private Dictionary<string, string> ProcessedStrings = new Dictionary<string, string>();
    private static string ProcessString(string input)
    {
        // If we've already encountered this string, return the cached result right away
        if (ProcessedStrings.ContainsKey(input)) return ProcessedStrings[input];
        // Process the string here
        var result = DoSomethingWithString(input);
        ProcessedStrings[input] = result;        
    }
