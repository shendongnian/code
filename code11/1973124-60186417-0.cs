    public class QuerystringInjectingHttpMessageHandler : DelegatingHandler
    {
        private readonly (string Key, string Value)[] injectedParameters;
    
        public QuerystringInjectingHttpMessageHandler(params (string key, string value)[] injectedParameters) : this()
        {
            this.injectedParameters = injectedParameters;
        }
    
        public QuerystringInjectingHttpMessageHandler() : base(new HttpClientHandler())
        {
        }
    
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var finalUri = InjectIntoQuerystring(request.RequestUri, injectedParameters);
    
            request.RequestUri = finalUri;
    
            return base.SendAsync(request, cancellationToken);
        }
    
        private static Uri InjectIntoQuerystring(Uri uri, IEnumerable<(string Key, string Value)> parameters)
        {
            var toString = uri.ToString();
            var currentParameters = HttpUtility.ParseQueryString(toString);
    
            foreach (var (key, value) in parameters)
            {
                currentParameters[key] = value;
            }
    
            var tuples = currentParameters.ToTuples();
    
            var newUri =
                string.Join("&", tuples.Select(tuple =>
                {
                    if (tuple.name == null)
                    {
                        return tuple.value;
                    }
    
                    return tuple.name + "=" + tuple.value;
                }));
            var finalUri = new Uri(newUri);
            return finalUri;
        }
    }
