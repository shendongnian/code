    /// <summary>
    /// Gets an object property's value, recursively traversing it's properties if needed.
    /// </summary>
    /// <param name="FrameObject">The object.</param>
    /// <param name="PropertyString">The object property string.
    /// Can be the property of a property. e.g. Position.X</param>
    /// <returns>The value of this object's property.</returns>
    private object GetObjectPropertyValue(Object FrameObject, string PropertyString)
    {
        object Result = FrameObject;
        string[] Properties = PropertyString.Split('.');
        foreach (var Property in Properties)
        {
            Result = Result.GetType().GetProperty(Property).GetValue(Result, null);
        }
        return Result;
    }
    public Type GetObjectPropertyType(string ObjectName, string PropertyString)
    {
        Object Result = GetObjectByName(ObjectName);
        
        string[] Properties = PropertyString.Split('.');
        foreach (var Property in Properties)
        {
            Result = Result.GetType().GetProperty(Property).GetValue(Result, null);
        }
        return Result.GetType();
    }
