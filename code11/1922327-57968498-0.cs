    public static List<PropertyInfo> GetDifferences(object test1, object test2)
    {
        if (test1 is null)
            throw new ArgumentNullException(nameof(test1));
        if (test2 is null)
            throw new ArgumentNullException(nameof(test2));
    
        List<PropertyInfo> differences = new List<PropertyInfo>();
        foreach (PropertyInfo property in test1.GetType().GetProperties())
        {
            if (test2.GetType().GetProperties().Any(a => a.Name.Equals(property.Name, StringComparison.Ordinal)))
            {
                object value1 = property.GetValue(test1, null);
                object value2 = property.GetValue(test2, null);
                if ((value1 == null) || !value1.Equals(value2))
                {
                    differences.Add(property);
                }
            }
        }
        return differences;
    }
