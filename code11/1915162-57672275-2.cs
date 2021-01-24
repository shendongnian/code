    int o;
    var orderOfDepts = new Dictionary<string, int> 
    {
       { "P", 0 },
       { "A", 1 },
       { "Z", 2 }
    };
    
    var sortedList = myList
                      .OrderBy(x => orderOfDepts.TryGetValue(x.dept, out o) ? o : int.MaxValue)
                      .ThenBy(x=> x.order)
                      .ToList();
