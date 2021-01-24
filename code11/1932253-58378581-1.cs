public class DiscConsumer
{
    //https://www.discogs.com/developers#page:authentication,header:authentication-discogs-auth-flow
    //curl "https://api.discogs.com/database/search?q=Nirvana" -H "Authorization: Discogs key=foo123, secret=bar456"
    private const string _urlQuery = "https://api.discogs.com/database/search?q={query}";
    private const string _key = "<....your key....>";
    private const string _secret = "<....your secret...>";
    private System.Net.Http.HttpClient _httpClient;
    public async Task InitilizeClient()
    {
        //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        var sslhandler = new HttpClientHandler()
        {
            //...in System.Security.Authentication.SslProtocols
            SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls
        };
        _httpClient = new System.Net.Http.HttpClient(sslhandler);
        string authorization = $"Discogs key={_key}, secret={_secret}";
        _httpClient.DefaultRequestHeaders.Add("Authorization", authorization);
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.120 Safari/537.36");
    }
    public async Task QueryDataBaseAsync(string query)
    {
        if (String.IsNullOrWhiteSpace( query ))
        {
            throw new Exception("query is empty");
        }
        string url = "";
        url = _urlQuery.Replace("{query}", query);
        if (_httpClient == null)
        {
            await InitilizeClient();
        }
        using (HttpResponseMessage response = await _httpClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                string s = await response.Content.ReadAsStringAsync();
                Console.WriteLine(s);
            }
            else
            {
                throw new Exception(response.ReasonPhrase + " \n" + response.RequestMessage.ToString());
            }
        }
    }
}
Per https://www.discogs.com/developers#page:authentication,header:authentication-discogs-auth-flow you can supply key+secret on every request along with search. 
