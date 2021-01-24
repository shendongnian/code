    void Main()
    {
        var strings = new List<string>();
        var filtredStrings = Filter(strings);
        strings.Add("item1");
        strings.Add("Life");
        strings.Add("Lasagna");
    
        foreach( var s in filtredStrings)
        {
            Console.WriteLine(s);
        }
    }
    
    // Define other methods, classes and namespaces here
    public static IEnumerable<String> Filter(List<string> strings)
    {
        // Don't call .ToList()
        return strings.Where(s => s.StartsWith("L")).OrderBy(s => s);
    }
