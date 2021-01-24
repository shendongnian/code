    void SomeMethod<T>(List<T> oldRecords, List<T> newRecords, List<string> propertiesOfT)
    {
        // get the list of property to match
        var properties = propertiesOfT.Select(prop => typeof(T).GetProperty(prop)).ToList();
        // Get all old record where we don't find any matching new record where all the property equal that old record
        var notMatch = oldRecords.Where(o => !newRecords.Any(n => properties.All(prop => prop.GetValue(o).Equals(prop.GetValue(n))))).ToList();            
    }
