    var myBinding = new BasicHttpBinding();
    myBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
    myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Digest;
    var myEndpoint = new EndpointAddress("http://server/myservice");
    var client = new MyServiceClient(myBinding, myEndpoint);
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
