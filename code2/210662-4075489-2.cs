    static bool GetValue(object currentObject, string propName, out object value)
    {
        // call helper function that keeps track of which objects we've seen before
        return GetValue(currentObject, propName, out value, new HashSet<object>());
    }
    static bool GetValue(object currentObject, string propName, out object value,
                         HashSet<object> searchedObjects)
    {
        PropertyInfo propInfo = currentObject.GetType().GetProperty(propName);
        if (propInfo != null)
        {
            value = propInfo.GetValue(currentObject, null);
            return true;
        }
        // search child properties
        foreach (PropertyInfo propInfo2 in currentObject.GetType().GetProperties())
        {   // ignore indexed properties
            if (propInfo2.GetIndexParameters().Length == 0)
            {
                object newObject = propInfo2.GetValue(currentObject, null);
                if (newObject != null && searchedObjects.Add(newObject) &&
                    GetValue(newObject, propName, out value, searchedObjects))
                    return true;
            }
        }
        // property not found here
        value = null;
        return false;
    }
