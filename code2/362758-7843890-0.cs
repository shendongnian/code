    using(var client = new WebClient())
    {
        client.Proxy = new WebProxy("localhost", 8888);
        Console.WriteLine(client.DownloadString("http://www.google.com"));
    }
