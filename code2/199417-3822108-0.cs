    public static bool PropertyCheck(this object o, string propertyName)
    {
        if (string.IsNullOrEmpty(propertyName))
            return false;
        Type type = (o is Type) ? o as Type : o.GetType();
        PropertyInfo pi = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
        if (pi != null && pi.PropertyType == typeof(string))
            return true;
        return false;
    }
