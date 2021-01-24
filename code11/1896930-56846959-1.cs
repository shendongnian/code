    ServiceReference1.TestServiceClient client = new ServiceReference1.TestServiceClient();
    client.ClientCredentials.UserName.UserName= "administrator";
    client.ClientCredentials.UserName.Password= "abcd1234!";
    client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
    new X509ServiceCertificateAuthentication()
    {
        CertificateValidationMode = X509CertificateValidationMode.None,
        RevocationMode = X509RevocationMode.NoCheck
    };
    try
    {
        var result = client.GetResult();
        Console.WriteLine(result);
    }
    catch (Exception)
    {
    
        throw;
    }
