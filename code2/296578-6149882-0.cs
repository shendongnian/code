    IEnumerable<IProperty> GetNonTypeProperties(IEnumerable<IProperty> properties)
    {
        return (from property in properties where property.Name != "Type" select property);
    }
    void foo()
    {
        foreach (var property in GetNonTypeProperties(properties))
        {
        }
    }
