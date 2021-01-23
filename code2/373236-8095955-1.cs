    //This is just temporary data.  Has the similar structure to what you want.
    var parts = new[]
                    {
                        new
                            {
                                Name = "X",
                                Property = new[] {'A', 'B', 'C'}
                            },
                        new
                            {
                                Name = "Y",
                                Property = new[] {'B', 'C', 'D'}
                            },
                        new
                            {
                                Name = "Z",
                                Property = new char[] { }
                            }
                        };
    
    var groupedBySub = from part in parts
                       from sub in part.Property
                       group part by sub;
    
    foreach(var group in groupedBySub)
    {
        Console.WriteLine("{0} - {1}", group.Key, string.Join(", ", group.Select(x => x.Name)));
    }
