    var list1 = new List<string>() {"A", "B", "C", "D", "E"};
    var list2 = new List<string>() {"A", "B", "A", "A", "C", "B", "D"};
    var dict = list2
      .Select((value, index) => new {value, index})     
      .GroupBy(pair => pair.value, pair => pair.index)
      .ToDictionary(group => group.Key, group => group.ToArray());
    foreach (var item in list1) 
      if (dict.TryGetValue(item, out int[] indexes))
        Console.WriteLine($"value {item} appears at [{string.Join(", ", indexes)}]");
    
