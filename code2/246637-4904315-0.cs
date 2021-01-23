    void InnerEnumerate (List<int> innerList)
    {
        foreach (var innerItem in innerList)
            Console.WriteLine ("- inner item {0}", innerItem);
    }
    
    var outerList = new List<int> { 1, 2, 3 };
    foreach (var outerItem in outerList) {
        Console.WriteLine ("Outer item {0}", outerItem);
        InnerEnumerate (outerList); // pass list as a parameter
    }
    
