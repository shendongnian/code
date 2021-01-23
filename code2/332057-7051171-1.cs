    private static ConvertibleKeyValuePair[] IncludeTest(params ConvertibleKeyValuePair[] items)
    {
        return items;
    }
    
    private static void TestImplicitConversion()
    {
        foreach (var item in IncludeTest("adam;1", "eva;2")) {
            Console.WriteLine("key = {0}, value = {1}", item.Key, item.Value);
        }
        Console.ReadKey();
    }
