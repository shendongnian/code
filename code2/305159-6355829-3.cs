    var client = new MyServiceClient();
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
