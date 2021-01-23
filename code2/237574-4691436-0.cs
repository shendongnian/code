    var type = myObjectOfSomeType.GetType();
    // now depending on what you want to store
    // I'll save all public properties
    var properties = type.GetProperties(); // get all public properties
    foreach(var p in properties)
    {
        var value = p.GetValue(myObjectOfSomeType, null);
        Writevalue(p.Name, value);
    }
