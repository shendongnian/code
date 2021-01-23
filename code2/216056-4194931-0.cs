    using(var client = new ServiceReference1.ThirdPartyServiceClient())
    {
        client.SendSomething("123", "hello");
        string output = client.GetSomething();
        Console.WriteLine(output);
    }
