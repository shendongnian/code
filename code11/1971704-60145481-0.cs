    static void Main(string[] args)
    {
        ServiceReference1.ServiceClient client = new ServiceClient();
        var result = client.Test();
        Console.WriteLine(result);
    }
