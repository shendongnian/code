    static void Main(string[] args)
    {
        ArrayList siteList = new ArrayList();
        siteList.Add("Test 1");
        siteList.Add("Test 2");
        foreach (var item in siteList)
        {
            Console.WriteLine(item);
        }
        SerializeArray(siteList);
        siteList = DeserializeArray();
        if (siteList.Contains("Test 2"))
        {
            Console.WriteLine("Test 2 exists!");
            Console.Read();
        }
    }
