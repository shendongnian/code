    private bool ValueWasSet(string propertyName)
    {
        var property = fields.GetType().GetProperty(propertyName);
        return (bool)property.GetValue(fields, null);
    }
    
    public List<string> GetVarList()
    {
        return new [] {"SearchBar", "SomeField"}
            .Where(ValueWasSet)
            .ToList();
    }
