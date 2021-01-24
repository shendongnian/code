    private string cachedUri;
    private string cachedResult;
    public string GetApiResult(string uri, bool useCachedResult = true)
    {
        // If we've already encountered this string, return the cached result right away
        if (useCachedResult && uri == cachedUri) return cachedResult;
        // Process the string here
        var result = MakeAPICall(uri);
        // Save it, along with the result, in our fields
        cachedUri = uri;
        cachedResult = result;
        // Return the result
        return result;
    }
