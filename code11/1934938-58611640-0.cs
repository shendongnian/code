    var clientSettings = MongoClientSettings.FromUrl(new MongoUrl(mongoUrl));
    clientSettings.UseTls = true;
    clientSettings.SslSettings = new SslSettings
    {
        EnabledSslProtocols = SslProtocols.Tls11,
        ServerCertificateValidationCallback = (sender, certificate, chain, errors) =>
            certificate.Subject.Contains("O=myOU,")
    };
