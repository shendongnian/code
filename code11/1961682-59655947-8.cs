    private readonly Dictionary<string, string> cachedResults = new Dictionary<string, string>();
    public string GetApiResult(string uri, bool useCachedResult = true)
    {
        // If we've already encountered this string, return the cached result right away
        if (useCachedResult && cachedResults.ContainsKey(uri)) return cachedResults[uri];
        // Process the string here
        var result = MakeAPICall(uri);
        // Save it, along with the result, in our dictionary
        cachedResults[uri] = result;
        // Return the result
        return result;
    }
