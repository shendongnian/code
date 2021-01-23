    IEnumerable<MyStruct> sequence = ...
    var query = sequence.GroupBy(s => s.Person)
                        .Select(g => new 
                                     { 
                                        Person = g.Key,
                                        Commands = g.Select(s => s.Command).ToArray() 
                                     })
                        .ToArray();
