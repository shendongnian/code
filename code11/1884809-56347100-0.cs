    using (var httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                    httpClientHandler.SslProtocols = System.Security.Authentication.SslProtocols.Tls;
                    //send request
                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        var content = new StringContent(body, Encoding.UTF8, "application/soap+xml");
                        HttpResponseMessage response = await httpClient.PostAsync(_url, content);
    
                    }
                }
