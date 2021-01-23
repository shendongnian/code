    private bool DoObjectsMatch(object obj1, object obj2, string propetyName)
    {
        PropertyInfo info = obj1.GetType().GetProperty(propertyName);
        if (info != null && info.CanRead)
            return info.GetValue(obj1, null).ToString() == info.GetValue(obj2, null).ToString();
        return false;
    }
