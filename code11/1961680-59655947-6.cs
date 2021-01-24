    private static readonly Dictionary<string, string> CachedResults = 
        new Dictionary<string, string>();
    public static string GetApiResult(string uri, bool useCachedResult = true)
    {
        // If we've already encountered this string, return the cached result right away
        if (useCachedResult && CachedResults.ContainsKey(uri)) return CachedResults[uri];
        // Process the string here
        var result = MakeAPICall(uri);
        // Save it, along with the result, in our dictionary
        CachedResults[uri] = result;
        // Return the result
        return result;
    }
