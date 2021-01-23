    private bool DoObjectsMatch(object obj1, object obj2, string propetyName)
    {
        PropertyInfo info = obj1.GetType().GetProperty(propertyName);
        if (info != null && info.CanRead)
            return info1.GetValue(obj1, null).ToString() == info2.GetValue(obj2, null).ToString();
        return false;
    }
