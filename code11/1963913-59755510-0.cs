    void Main()
    {
        var h1 = new HashSet<int>() { 1, 2, 3, 4, 5 };
        var h2 = new HashSet<int>() { 6, 7, 8, 9, 10 };
        var h3 = new HashSet<int>() { 11, 12, 13, 14, 15 };
        
        foreach (var i in enumerateCollections(h1, h2, h3))
        {
            Console.WriteLine(i);
        }
    }
    
    private IEnumerable<T> enumerateCollections<T>(params IEnumerable<T>[] collections)
    {
        foreach (var coll in collections)
        {
            foreach (var value in coll)
            {
                yield return value;
            }
        }
    }
