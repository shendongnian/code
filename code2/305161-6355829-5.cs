    var binding = new BasicHttpBinding();
    binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Digest;
    var endpoint = new EndpointAddress("http://server/myservice");
    var client = new MyServiceClient(binding, endpoint);
    // We have to set the actual credentials on the client proxy object
    // before invoking the service:
    client.ClientCredentials.HttpDigest.ClientCredential.UserName = "me";
    client.ClientCredentials.HttpDigest.ClientCredential.Password = "password";
    
    try
    {
        client.MyServiceOperation();
        client.Close();
    }
    catch
    {
        client.Abort();
    }
