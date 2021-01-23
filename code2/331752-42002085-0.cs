    public class WebPostTarget : Target
    {
        public string ServerUrl { get; set; }
        private readonly HttpClient _client = new HttpClient();
        
        protected override void Write(LogEventInfo logEvent)
        {
            PostData(new [] { logEvent.AsLogModel() }); 
        }
        protected override void Write(AsyncLogEventInfo[] logEvents)
        {
            var data = logEvents.Select(x => x.LogEvent.AsLogModel()).ToArray();
            PostData(data);
        }
        private void PostData(object data)
        {
            if (!ServerUrl.IsNullOrEmpty())
            {
                // add your custom headers to the client if you need to 
                _client.PostJsonAsync(ServerUrl, data).FireAndForget();
            }
        }
    }
    // HttpClientExtensions
    public static async Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string url, object data)
    {
        return await client.PostAsync(url, new StringContent(data.ToJson(), Encoding.UTF8, "application/json"));
    }
