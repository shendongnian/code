    public static void Method(IEnumerable<MyStructure> items)
    {
        foreach(var item in items) Console.WriteLine(item.Name);
    }
    ...
    MyStructure.Method(List);
