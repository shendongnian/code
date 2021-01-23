    // The instance, it can be of any type.
    object o = <some object>;
    
    // Get the type.
    Type type = o.GetType();
    
    // Get all public instance properties.
    // Use the override if you want to classify
    // which properties to return.
    foreach (PropertyInfo info in type.GetProperties())
    {
        // Do something with the property info.
        DoSomething(info);
    }
