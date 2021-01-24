    private static string _cachedUri;
    private static string _cachedResult;
    public static string GetApiResult(string uri, bool useCachedResult = true)
    {
        // If we've already encountered this string, return the cached result right away
        if (useCachedResult && uri == _cachedUri) return _cachedResult;
        // Process the string here
        var result = MakeAPICall(uri);
        // Save it, along with the result, in our fields
        _cachedUri = uri;
        _cachedResult = result;
        // Return the result
        return result;
    }
