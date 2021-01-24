    //client is a proxy class object.
               client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
        new X509ServiceCertificateAuthentication()
        {
            CertificateValidationMode = X509CertificateValidationMode.None,
            RevocationMode = X509RevocationMode.NoCheck
        };
