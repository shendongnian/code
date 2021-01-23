    private void DoProperties(object obj)
    {
        Type objectType = obj.GetType();
        var propertyInfo = objectType.GetProperty("Properties", typeof(PropertyCollection));
        PropertyCollection properties = (PropertyCollection)propertyInfo.GetValue(obj, null);
        foreach (var prop in properties)
        {
            //    string name = prop.Name;
            //    string value = prop.Value;
        }
    }
