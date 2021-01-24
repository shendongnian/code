    private static Dictionary<string, string> cachedResults = new Dictionary<string, string>();
    public static string ProcessString(string input)
    {
        // If we've already encountered this string, return the cached result right away
        if (cachedResults.ContainsKey(input)) return cachedResults[input];
        // Process the string here
        var result = DoSomethingWithString(input);
        // Save it, along with the result, in our dictionary
        cachedResults[input] = result; 
        // Return the result
        return result;       
    }
