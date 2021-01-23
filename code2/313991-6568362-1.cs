    public string GetArgumentValueByName(string queryString, string paramName)
    {
        var paramCol = HttpUtility.ParseQueryString(queryString);
        return paramCol[paramName] ?? string.Empty;        
    }
