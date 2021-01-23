    private void OnServiceConfigurationCreated(object sender, 
        ServiceConfigurationCreatedEventArgs e)
    {
        var sessionTransforms =
            new List<CookieTransform>(
                new CookieTransform[] 
                {
                    new DeflateCookieTransform(), 
                    new RsaEncryptionCookieTransform(
                      e.ServiceConfiguration.ServiceCertificate),
                    new RsaSignatureCookieTransform(
                      e.ServiceConfiguration.ServiceCertificate)  
                });
        var sessionHandler = new 
         SessionSecurityTokenHandler(sessionTransforms.AsReadOnly());
        e.ServiceConfiguration.SecurityTokenHandlers.AddOrReplace(
            sessionHandler);
    }
