    public static void Test()
    {
        var items = new List<object>() { new Class1 { Foo = "foo1", Bar1 = "Bar1" }, new Class2 { Foo = "foo1", Bar2 = "Bar2" } };
        int totalCount = 1;
        int min = 2;
        int max = 3;
        var root = new
        {
            totalCount,
            min,
            max,
            items,
        };
        var json = JsonSerializer.Serialize<object>(root, new JsonSerializerOptions { WriteIndented = true, });
        Console.WriteLine(json);
    }
If you create the items as `List<object>`, you dont have to change or do anything. This might be a cleaner way instead of casting each of them to object at time of creating the object.
