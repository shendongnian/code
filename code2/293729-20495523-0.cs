    string GetQueryString(string url, string key)
    {
        string query_string = string.Empty;
        
        var uri = new Uri(url);
        var newQueryString = HttpUtility.ParseQueryString(uri.Query);
        query_string = newQueryString[key].ToString();
        return query_string;
    }
