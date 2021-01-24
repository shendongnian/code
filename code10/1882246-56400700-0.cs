    public class AuthorizingHandler : DelegatingHandler
    {
        private readonly OAuthOptions _options;
        public AuthorizingHandler(HttpMessageHandler inner, OAuthOptions options)
            : base(inner)
        {
            _options = options;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(request.RequestUri == new Uri(_options.TokenEndpoint))
            {
                string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(_options.ClientId + ":" + _options.ClientSecret));
                request.Headers.Add("Authorization", $"Basic {credentials}");
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
