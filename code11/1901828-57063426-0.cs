    private string GetRFAPI(string str)
    {
        return GetSubstring(str, "Request for API: ", ' ', 1);
    }
    
    private string GetCaller(string str)
    {
        return GetSubstring(str, "Caller:", ' ', 1);
    }
    
    private string GetCorrelationId(string str)
    {
        return GetSubstring(str, "CorrelationId: ", ' ', 1);
    }
    
    private string GetTenantId(string str)
    {
        return GetSubstring(str, "TenantId: ", ' ', 1);
    }
    
    private string GetRequestedSchemas(string str)
    {
        return GetSubstring(str, "RequestedSchemas: ", ',', 2);
    }
    
    private string GetSubstring(string str, string pattern, char delimiter, int occurrence)
    {
        int start = str.IndexOf(pattern);
        if (start < 0)
        {
            return null;
        }
    
        for (int i = start + pattern.Length, counter = 0; i < str.Length; i++, counter++)
        {
            if ((str[i] == delimiter && --occurrence == 0) || i == str.Length - 1)
            {
                return str.Substring(start + pattern.Length, counter).Trim();
            }
        }
    
        return null;
    }
