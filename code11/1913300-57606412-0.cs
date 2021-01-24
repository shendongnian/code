    public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
     {
         if (request == null)
         {
             throw new ArgumentNullException("request");
         }
    
         var accessToken = await PreAuthenticate(request.RequestUri).ConfigureAwait(false);
         if (!string.IsNullOrEmpty(accessToken))
             request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
         else
         {
             var httpClientHandler = new WinHttpHandler()
             {
                 WindowsProxyUsePolicy = WindowsProxyUsePolicy.UseCustomProxy,
                 Proxy = new MyWebProxy(configuration),
                 SendTimeout = TimeSpan.FromSeconds(120),
                 ReceiveDataTimeout = TimeSpan.FromSeconds(120),
                 ReceiveHeadersTimeout = TimeSpan.FromSeconds(120),
             };
 
