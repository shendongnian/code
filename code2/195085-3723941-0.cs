    public bool ValidateData(object data)
    {
        foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
        {
            if (propertyInfo.PropertyType == typeof(string))
            {
                string value = propertyInfo.GetValue(data, null);
    
                if value is not OK
                {
                    return false;
                }
            }
        }            
    
        return true;
    }
