    if (test is IEnumerable) {
        var values = test as IEnumerable;
        
        //Method 1: convert to list
        var asList = values.Cast<object>().ToList();
        //Method 2: iterate to IEnumerable and add to List
        var asList = new List<object>();
        foreach (var value in values)
        {
            asList.Add(value);
        }
    }
