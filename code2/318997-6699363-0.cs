    foreach (var obj1Property in obj1.GetType().GetProperties())
    {
        var obj2Property = obj2.GetType().GetProperty(obj1Property.Name);
        obj2Property.SetValue(obj2, obj1Property.GetValue(obj1, null), null);
    }
