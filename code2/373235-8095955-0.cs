    var parts = new[]
                    {
                        new
                            {
                                Property = new[] {'A', 'B', 'C'}
                            },
                        new
                            {
                                Property = new[] {'B', 'C', 'D'}
                            }
                    };
    
    var groupedBySub = from part in parts
                       from sub in part.Property
                       group part by sub;
    
    foreach(var group in groupedBySub)
    {
        Console.WriteLine("{0} - Count: {1}", group.Key, group.Count());
    }
