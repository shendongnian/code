    public void ClearDatabase()
    {
        var properties = typeof(MockDatabase).GetProperties();
    
        foreach (var property in properties)
        {
            if (property.PropertyType.Name == typeof(List<>).Name || property.PropertyType.Name == typeof(IList<>).Name)
            {
                property.SetValue(this, null);
            }
        }
    }
