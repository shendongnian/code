    var properties = entry.GetType().GetProperties().Where(x => x.PropertyType.GetInterface(typeof(ISeedData).Name) != null);
    foreach (var staticProperty in properties)
    {
        var n = staticProperty.GetValue(entry, null);
        Entry(n).State = EntityState.Unchanged;
    }  
