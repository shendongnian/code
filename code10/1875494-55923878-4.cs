    static void Main(string[] args)
    {
        ...
        var details = CallRestMethodAsync(url, filterObj);
        Console.Write(details.Result);
        Console.ReadKey();
    }
