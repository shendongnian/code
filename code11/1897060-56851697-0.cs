    services.AddHttpClient("MyClient", client => {
        client.Timeout = TimeSpan.FromMinutes(1),
        client.BaseAddress = new Uri(_Settings.BaseUrl)
    })
    .ConfigurePrimaryHttpMessageHandler(() => {
        var httpClientHandler = new HttpClientHandler
        {
            SslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12,
            ClientCertificateOptions = ClientCertificateOption.Manual
        };
        httpClientHandler.ClientCertificates.Add(CertHelper.GetCertFromStoreByThumbPrint(_Settings.MtlsThumbPrint, StoreName.My, _Settings.IgnoreCertValidChecking));
        
        httpClientHandler.ServerCertificateCustomValidationCallback = OnServerCertificateValidation;
        return httpClientHandler;
    });
