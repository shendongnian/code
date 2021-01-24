    void Main()
    {
        var dnsHandler = new DnsHandler(new CustomDnsResolver());
        var client = new HttpClient(dnsHandler);
        var html = client.GetStringAsync("http://google.com").Result;
    }
    
    public class DnsHandler : HttpClientHandler
    {
        private readonly CustomDnsResolver _dnsResolver;
    
        public DnsHandler(CustomDnsResolver dnsResolver)
        {
            _dnsResolver = dnsResolver;
        }
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var host = request.RequestUri.Host;
            var ip = _dnsResolver.Resolve(host);
            
            var builder = new UriBuilder(request.RequestUri);
            builder.Host = ip;
            
            request.RequestUri = builder.Uri;
            
            return base.SendAsync(request, cancellationToken);
        }
    }
    
    public class CustomDnsResolver
    {
        public string Resolve(string host)
        {
            return "127.0.0.1";
        }
    }
