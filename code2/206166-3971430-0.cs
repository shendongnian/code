    // The ToList() call here is important, so that we evaluate all of the query
    // *before* we start modifying the dictionary
    var keysToModify = CustomerOrderDictionary.Keys
                                              .Where(k => k.Id == 1)
                                              .ToList();
    foreach (var key in keysToModify)
    {
        CustomerOrderDictionary[key] = 4;
    }
