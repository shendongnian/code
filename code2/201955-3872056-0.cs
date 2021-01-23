        Dictionary<int, string> dict = new Dictionary<int, string>
        { 
            {3, "kuku" },
            {1, "zOl"}
        };
        List<int> data = new List<int> { 1, 2, 4 };
        List<int> toRemove = dict.Keys.Where(k => !data.Contains(k)).ToList();
        foreach (int k in toRemove)
            dict.Remove(k);
        foreach (var p in dict)
            Console.WriteLine(p);
