    strong textvar test2 = new Dictionary<string, List<int>>();
    var myNewList = test2.GetOrCreate("Derp");
    myNewList.Add(10); 
    // or
    var test2 = new Dictionary<string, List<int>>();
    test2.GetOrCreate("Derp").Add(10); // winning!
