    /// <summary>
    /// this method makes a copy of object as a clone function
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static object Clone_Control(object o)
    {
        Type type = o.GetType();
        PropertyInfo[] properties = type.GetProperties();
        Object retObject = type.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, o, null);
        foreach (PropertyInfo propertyInfo in properties)
        {
            if (propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(retObject, propertyInfo.GetValue(o, null), null);
            }
        }
        return retObject;
    }
