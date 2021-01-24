c#
const string ApiServer = "https://google.com";
static readonly HttpClient _httpClient = new HttpClient();
static async Task Main()
{
    InitializeClient();
    var headers = new Dictionary<string, string>()
    {
        { "Authorization", "Bearer e45jsh56" },
        { "Test", "test_value" }
    };
    var paramterers = new Dictionary<string, string>()
    {
        { "pageNum", "3" },
        { "pageSize", "100" }
    };
    var response = await MakeApiCallAsync("mypath", "request_body", headers, paramterers, "GET");
    Console.WriteLine($"Status Code: {response.StatusCode}.");
}
static void InitializeClient()
{
    //  Set the base URI
    _httpClient.BaseAddress = new Uri(ApiServer);
    //  Set Timeout to 5 seconds
    _httpClient.Timeout = new TimeSpan(hours: 0, minutes: 0, seconds: 5);
    //  Set the default User Agent
    _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("VSpedSync/DevBuild");
}
static async Task<ApiResponse> MakeApiCallAsync(string path, 
    string body, Dictionary<string, string> headers, 
    Dictionary<string, string> query, string method)
{
    //  Generate query string
    string queryString = '?' + 
        string.Join(separator: '&', values: query.Select(q => $"{q.Key}={q.Value}"));
    //  Create the relative URL
    string relativeUrl = path + queryString;
    //  Create the Http Method object
    HttpMethod httpMethod = new HttpMethod(method);
    //  Create the request object
    HttpRequestMessage request = new HttpRequestMessage(httpMethod, relativeUrl);
    //  Set headers to the request
    foreach (KeyValuePair<string, string> h in headers)
    {
        if (!h.Key.Equals("UserAgent", StringComparison.OrdinalIgnoreCase))
        {
            request.Headers.Add(h.Key, h.Value);
        }
    }
    //  Set the content of the request
    if (!string.IsNullOrEmpty(body))
    {
        request.Content = new StringContent(body);
    }
    //  Send the request
    HttpResponseMessage response = await _httpClient.SendAsync(request);
    //  Display request headers
    foreach(var h in request.Headers)
    {
        Console.WriteLine($" --> {h.Key}: {string.Join(';', h.Value)}.");
    }
    //  Process the response body
    string responseBody = "NONE";
    try
    {
        //  Read the content as a string
        responseBody = await response.Content.ReadAsStringAsync();
    }
    catch
    {
        responseBody = "ERROR";
    }
    //  Return the api response
    return new ApiResponse
    {
        StatusCode = response.StatusCode,
        ResponseBody = responseBody,
        ValidResponse = !responseBody.Equals("NONE") && !responseBody.Equals("ERROR"),
        ResponseHeaders = response.Headers.ToDictionary(h => h.Key, h => string.Join(';', h.Value)),
    };
}
Output
 --> Authorization: Bearer e45jsh56.
 --> Test: test_value.
 --> User-Agent: VSpedSync/DevBuild.
Status Code: BadRequest.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.8
