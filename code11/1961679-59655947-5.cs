    private static string cachedUri = null;
    private static string cachedResult = null;
    public static string GetAPIResult(string input, bool useCachedResult = true)
    {
        // If we've already encountered this string, return the cached result right away
        if (useCachedResult && input == cachedUri) return cachedResult;
        // Process the string here
        var result = MakeAPICall(input);
        // Save it, along with the result, in our fields
        cachedUri = input;
        cachedResult = result; 
        // Return the result
        return result;       
    }
