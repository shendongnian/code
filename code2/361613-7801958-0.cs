    foreach (var property in MyObject.GetType().GetProperties()
        .Select(pi => pi.GetValue(MyObject, null)))
    {
        property.GetType().GetMethod("doStuff").Invoke(property, null);
    }
