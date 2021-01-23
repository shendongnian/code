    SortedDictionary<int, int> dictionary = new SortedDictionary<int, int>()
                                                {
                                                    {1, 20},
                                                    {2, 8},
                                                    {3, 10},
                                                    {4, 5}
                                                };
    var result = Enumerable
        .Range(0, dictionary.Keys.Count)
        .Select(i => new
                            {
                                Key = dictionary.Keys.Skip(i).First(),
                                Value = dictionary.Take(i+1).Select(k => k.Value).Sum()
                            })
        .ToDictionary(k => k.Key, v => v.Value);
            
    foreach(var r in result)
    {
        Console.WriteLine("Key = {0}, Value = {1}", r.Key, r.Value);
    }
                
            
    Console.WriteLine("done");
    Console.ReadLine();
