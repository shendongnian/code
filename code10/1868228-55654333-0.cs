    using (var httpClientHandler = new HttpClientHandler { Credentials = CredentialCache.DefaultNetworkCredentials })
    {
        bool disposeHandler = true; //Setting true or false does not fix the problem
        using (var httpClient = new HttpClient(httpClientHandler, disposeHandler))
        {
            using (var content = new ByteArrayContent(Encoding.UTF8.GetBytes("Hello")))
            {
                // Commenting/uncommenting the line below does not fix the problem
                // httpRequestMessage.Headers.Connection.Add("Keep-Alive");
    
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://SomeUrl")
                {
                    Content = content,
                    Version = HttpVersion.Version10
                };
    
                using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage)) // This line still throws but with the real exception (and not the ObjectDisposedException)
                {
    
                }
            }
        }
    }
