    // The custom data structure, deserialized from JSON.
    CustomData data = ...;
    // The type of Employee.
    Type type = typeof(Employee);
    // Create a map of the property info to the ordinal in the
    // Columns.
    IDictionary<int, PropertyInfo> propertyMap = data.Columns.
        Select((p, i) => 
            new { Index = i, PropertyInfo = type.GetProperty(p) }).
        ToDictionary(p => p.Index, p => p.PropertyInfo);
    // Cycle through the rows in the data.
    var query =
        // Cycle through all of the rows.
        from row in Enumerable.Range(0, data.Data.GetLength(0))
        // Create the instance.
        let instance = new Employee()
        // For each column in the row.
        from column in Enumerable.Range(0, data.Data.GetLength(1))
        // Lookup the property info.
        let propertyInfo = propertyMap[column]
        // Select the instance, the property, and the value.
        select { 
            // This is used for grouping purposes, since
            // you can't guarantee that the type you are serializing
            // to will have natural identity properties and
            // you know the row corresponds to one singular instance.
            Row = row,
            Instance = instance, 
            PropertyInfo = propertyInfo,
            Value = data.Data[row, column]
        };
    // Iterate through the items, setting the instance values.
    foreach (var propertyAndData in query)
    {
        // Set the property value on the instance.
        propertyAndData.PropertyInfo.
            SetValue(propertyAndData.Instance, Value, null);
    }
    // Group by the row and get the first item in each sequence.
    IEnumerable<Employee> employees =
        from item in query
        groupby item by item.Row into g
        select g.First();
