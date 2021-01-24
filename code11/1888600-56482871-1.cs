    internal class DataAdapter : IDataAdapter
    {
        public HttpClient Client => staticClient.Value;
    
        static Lazy<HttpClient> staticClient = new Lazy<HttpClient>(()=>
        {
            // This implementation is unique to the API
            var client = new HttpClient();
            client.AcceptHeader(MediaType.Json);
            client.AuthorizationHeader("123456");
            client.Timeout = TimeSpan.FromSeconds(300);
            return client;    
        });
    }
