    public class TestLogic : IDispose {
    private HttpClientHandler _Handler;
    // I would handle the login and password in a own config object 
    public TestLogic(HttpClientHandler handler, Config config )
    {
        _Handler = handler ?? throw new ArgumentException(); 
    }
    public async Task<ApiDataResponse> PostfetchTokenrequestBodyAsync()
    {
        List<KeyValuePair<string, string>> fetchTokenrequest = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("login", TestFetchTokenLogin),
            new KeyValuePair<string, string>("password", TestFetchTokenKey)
        };
        FormUrlEncodedContent fetchTokenrequestBody = new FormUrlEncodedContent(fetchTokenrequest);
        var fetchTokenResponse = await httpClient.PostAsync(TestFetchTokenUri, fetchTokenrequestBody).ConfigurationAwait(false);
        fetchTokenResponse.EnsureSuccessStatusCode();
        var tokenResponse = JToken.Parse(await fetchTokenResponse.ReadAsStringAsync().ConfigurationAwait(false));
        var token = tokenResponse?.SelectToken("access_token")?.ToString();
        return tokenResponse;
    }
    public async Task<ApiDataResponse> GetHinterlandFetchDataUriAsync(string token, ...)
    {
        var apiResponse = httpClient.GetAsync($"{HinterlandFetchDataUri}?restapi.session_key={token}&param1={param1}&param2={param2}&sub_param2={param3}&param4={param4}&OutputFormat=json");
        apiResponse.EnsureSuccessStatusCode(); // handle exception 
        
        var result = await apiResponse.Result.Content.ReadAsStringAsync().ConfigurationAwait(false);
        
        return = new ApiDataResponse
        {
            Success = true,
            Response = result
        };
    }
    // implement IDisposable interface correct https://docs.microsoft.com/de-de/dotnet/api/system.idisposable?view=netframework-4.7.2
}
