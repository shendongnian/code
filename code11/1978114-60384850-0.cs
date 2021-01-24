    List<DataClass> list = new List<DataClass>();
    list.Add(new DataClass { Number1 = 1, Number2 = 100 });
    list.Add(new DataClass { Number1 = 2, Number2 = 100 });
    list.Add(new DataClass { Number1 = 3, Number2 = 101 });
    list.Add(new DataClass { Number1 = 4, Number2 = 102 });
    list.Add(new DataClass { Number1 = 5, Number2 = 103 });
    list.Add(new DataClass { Number1 = 6, Number2 = 104 });
    list.Add(new DataClass { Number1 = 7, Number2 = 104 });
    
    var unique = new Dictionary<int, DataClass>();
    var repeated = new List<DataClass>();
    var result = new Dictionary<int, IEnumerable<DataClass>>();
    
    foreach (var obj in list)
        if (!unique.TryAdd(obj.Number2, obj))
            repeated.Add(obj);
    
    result.Add(1, unique.Values);
    result.Add(2, repeated);
