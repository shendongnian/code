    List<string> items = new List<string> {
        "Milk, 2",
        "Eggs, 4",
        "Juice, 1"
    };
    var dictionary = items.Select(s => s.Split(',')) 
                          .ToDictionary(x => x[0], x => Int32.Parse(x[1]));
 
    bool contains = dictionary.ContainsKey("Milk");
