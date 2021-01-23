    public string GetArgumentValueByName(string queryString, string paramName)
    {
        var paramCol = HttpUtility.ParseQueryString(queryString);
        if (paramCol.Keys.Contains(paramName))
        {
             return paramCol[paramName];
        }
        return string.Empty;
    }
