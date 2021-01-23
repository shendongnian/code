    var flags = BindingFlags.Public | BindingFlags.Static;
    var query = typeof(MyClass)
            .GetProperties(flags)
            .Where(propertyInfo => propertyInfo.PropertyType == typeof(string))
            .Select(propertyInfo => propertyInfo.GetValue(null, null));
    foreach (var value in query) {
        // ...
    }
