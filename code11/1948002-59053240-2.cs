    public class AutoRefreshingCredentials  : ServiceClientCredentials
    {
        public const string AuthorizationHeader = "Authorization";
        public AutoRefreshingCredentials (HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public HttpClient HttpClient { get; }
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // TODO: Check if token is valid and/or obtain a new one
            string token = await GetOrRefreshTokenAsync(...);
            request.Headers.Add(AuthorizationHeader, token);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
