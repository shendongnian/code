    public class CustomHttpHandler : HttpClientHandler
    {
        private readonly Dictionary<string, X509Certificate> _certMap;
        public CustomHttpHandler():base()
        {
            _certMap = new Dictionary<string, X509Certificate>() { { "server1name", new X509Certificate("cert1") }, { "server2name", new X509Certificate("cert2") } };
        }
        
        protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
        {
            string serverName = request.RequestUri.Host;
            if (ClientCertificates.Contains(_certMap[serverName]))
            {
                try
                {
                    var response = await base.SendAsync(request, cancellationToken);
                    return response;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    throw;
                }
            }
            else
            {
                ClientCertificates.Clear();
                ClientCertificates.Add(_certMap[serverName]);
                try
                {
                    var response = await base.SendAsync(request, cancellationToken);
                    return response;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    throw;
                }
            }
        }
    }
