    var list1 = new List<string>() {"A", "B", "C", "D", "E"};
    var list2 = new List<string>() {"A", "B", "A", "A", "C", "B", "D"};
    var dict = list2
      .Select((value, index) => new {value, index})     
      .GroupBy(pair => pair.value, pair => pair.index)
      .ToDictionary(group => group.Key, group => group.ToArray());
    for (int i = 0; i < list1.Count; ++i) {
      var item = list1[i];
 
      if (dict.TryGetValue(item, out int[] indexes))
        Console.WriteLine(
          $"value {item} at {index} appears in list2 at [{string.Join(", ", indexes)}]");
      else 
        Console.WriteLine($"value {item} at {index} doesn't appear in list2");
    }
    
