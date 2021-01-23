    foreach (var info in obj1.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
    {
        var val1 = info.GetValue(obj1, null);
        var val2 = info.GetValue(obj2, null);
        // check if val1 == val2
    }
