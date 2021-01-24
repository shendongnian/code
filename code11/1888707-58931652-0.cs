    namespace StocksApi2.httpClients
    {
        public interface IAlphavantageClient
        {
            Task<string> GetSymboleDetailes(string queryToAppend);
        }
        public class AlphavantageClient : IAlphavantageClient
        {
            private readonly HttpClient _client;
            public AlphavantageClient(HttpClient httpClient)
            {
                httpClient.BaseAddress = new Uri("https://www.alphavantage.co/query?apikey=<REPLACE WITH YOUR TOKEN>&");
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json; charset=utf-8");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
           
                _client = httpClient;
            }
            public async Task<string> GetSymboleDetailes(string queryToAppend)
            {
                _client.BaseAddress = new Uri(_client.BaseAddress + queryToAppend);
                return await _client.GetStringAsync("");
            }
        }
    }
