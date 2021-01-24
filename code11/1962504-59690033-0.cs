c#
public static ApiResponse MakeApiRequest(string path, string body, Dictionary<string, string> headers,
    Dictionary<string, string> query, string method)
{
    //  Generate the query string
    string queryString = '?' +
        string.Join(separator: '&', values: query.Select(q => $"{q.Key}={q.Value}"));
    //  Create request obejct
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ApiServer + path + queryString));
    request.Timeout = 5000;
    request.UserAgent = "VSpedSync/DevBuild";
    request.Method = method;
    //  Set headers to the request
    foreach (KeyValuePair<string, string> h in headers)
    {
        if (h.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
        {
            request.Headers.Add(HttpRequestHeader.Authorization, h.Value);
        }
        else if (!h.Key.Equals("UserAgent", StringComparison.OrdinalIgnoreCase))
        {
            request.Headers.Add(h.Key, h.Value);
        }
    }
    foreach (string requestHeader in request.Headers)
    {
        Debug.WriteLine(" --> " + requestHeader + ": " + request.Headers.Get(requestHeader));
    }
    // ...
    // .... Continue ....
    // ...
    return null;
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.net.webheadercollection.add?view=netframework-4.8#System_Net_WebHeaderCollection_Add_System_Net_HttpRequestHeader_System_String_
