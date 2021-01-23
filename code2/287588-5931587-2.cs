    static void Main(string[] args)
    {
        ArrayList siteList = DeserializeArray();
        siteList.Add("Test 3");
        siteList.Add("Test 4");
        foreach (var item in siteList)
        {
            Console.WriteLine(item);
        }
        SerializeArray(siteList);
        Console.Read();
    }
