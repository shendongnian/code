    public static string SetPageParameter(this string url, int pageNumber)
    {
        var queryStartIndex = url.IndexOf("?") + 1;
        if (queryStartIndex == 0)
        {
            return string.Format("{0}?page={1}", url, pageNumber);
        }
        var oldQueryString = url.Substring(queryStartIndex);
        var queryParameters = HttpUtility.ParseQueryString(oldQueryString);
        queryParameters["page"] = pageNumber;
        return url.Substring(0, queryStartIndex) + queryParameters.ToString();
    }
