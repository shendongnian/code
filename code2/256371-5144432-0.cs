    private string GetStringValue(object input, string propertyName)
    {
        PropertyInfo pi = typeof(input).GetProperty(propertyName);
        return pi.GetGetMethod().Invoke(input) as String;
    }
