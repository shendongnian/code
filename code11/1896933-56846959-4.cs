    ServiceReference1.TestServiceClient client = new ServiceReference1.TestServiceClient();
    client.ClientCredentials.UserName.UserName= "administrator";
    client.ClientCredentials.UserName.Password= "abcd1234!";
    try
    {
        var result = client.Add(1,3);
        Console.WriteLine(result);
    }
    catch (Exception)
    {
        throw;
    }
