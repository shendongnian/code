    private static HttpClient Client = new HttpClient(); 
    
    Uri uri = new Uri("https://thirdparty.com/service.svc");
    X509Certificate2 cert = // from some store etc
    var envelope = BuildEnvelope(cert);
    
    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri))
    {
        request.Content = new StringContent(envelope, Encoding.UTF8, "application/soap+xml");
        using (HttpResponseMessage response = Client.SendAsync(request).Result)
        {
            if (response.IsSuccessStatusCode)
            {
                response.Content.ReadAsStringAsync().ContinueWith(task =>
                {
                    string thirdparty_envelope = task.Result;
                    XElement thirdparty_root = XElement.Parse(thirdparty_envelope);
                    // etc
                }, TaskContinuationOptions.ExecuteSynchronously);
            }
        }
    }
