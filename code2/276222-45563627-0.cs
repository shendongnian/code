    public Dictionary<string, string> GetClassFields(TEntity obj)
    {
        Dictionary<string, string> dctClassFields = new Dictionary<string, string>();
    
        foreach (PropertyInfo property in obj.GetType().GetProperties())
        {
            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) && property.PropertyType.GetGenericArguments().Length > 0)
                dctClassFields.Add(property.Name, property.PropertyType.GetGenericArguments()[0].FullName);
            else
                dctClassFields.Add(property.Name, property.PropertyType.FullName);
        }
    
        return dctClassFields;
    }
