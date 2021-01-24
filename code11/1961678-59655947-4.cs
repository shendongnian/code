    private static Dictionary<string, string> cachedResults = new Dictionary<string, string>();
    public static string GetAPIResult(string input, bool useCachedResult = true)
    {
        // If we've already encountered this string, return the cached result right away
        if (useCachedResult && cachedResults.ContainsKey(input)) return cachedResults[input];
        // Process the string here
        var result = MakeAPICall(input);
        // Save it, along with the result, in our dictionary
        cachedResults[input] = result; 
        // Return the result
        return result;       
    }
