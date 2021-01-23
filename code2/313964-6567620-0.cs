    var resultingList = GetCrossProduct(blargh); // where blargh is the array you passed in
    foreach (IList<object> innerList in resultingList)
    {
        foreach (var listValue in innerList)
        {
            // listValues should be the individual strings, do whatever with them
            // e.g.
            Console.Out.WriteLine(listValue);
        }
    }
