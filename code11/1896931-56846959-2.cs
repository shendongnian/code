    BasicHttpBinding binding = new BasicHttpBinding();
    Uri uri = new Uri("http://10.157.13.69:3336");
    ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, new EndpointAddress(uri));
    factory.Credentials.UserName.UserName = "test";
    factory.Credentials.UserName.Password = "abcd1234!";
    IService service = factory.CreateChannel();
    try
    {
        var result = service.Add(2, 2);
    }
    catch (Exception)
    {
    
        throw;
    }
