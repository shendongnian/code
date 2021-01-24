    ServiceReference1.TestServiceClient client = new ServiceReference1.TestServiceClient();
    try
    {
        var result = client.GetResult();
        Console.WriteLine(result);
    }
    catch (Exception)
    {
        throw;
    }
    client.Close();
