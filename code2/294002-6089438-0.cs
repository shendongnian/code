    context.GetType().GetProperties()
    .Where(propertyInfo => propertyInfo.PropertyType == typeof(Table<>))
    .Select(propertyInfo => propertyInfo.GetValue(context, null) as ITable).ToList()
    .Foreach(table =>
    {
        //code that deletes the actual tables records.
    }
    );
