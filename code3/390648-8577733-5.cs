    private bool DoObjectsMatch(object obj1, object obj2, string propetyName)
    {
        PropertyInfo info1 = obj1.GetType().GetProperty(propertyName);
        PropertyInfo info2 = obj2.GetType().GetProperty(propertyName);
        if (info1 != null && info1.CanRead && info2 != null && info2.CanRead)
            return info1.GetValue(obj1, null).ToString() == info2.GetValue(obj2, null).ToString();
        return false;
    }
