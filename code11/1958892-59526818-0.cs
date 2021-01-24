// Check if the object has said property
public static bool HasProperty(this object obj, string property)
{
    return obj.GetType().GetProperty(property) != null;
}
// Get property value
public static object GetPropertyValue(this object obj, string property)
{
    return obj.GetType().GetProperty(property).GetValue(obj, null);
}
public static bool HasDesiredValue(Abc abcObject, Type fieldType, string value)
{
    if (abcObject.HasProperty(fieldType.Name))
    {
        if (abcObject.GetPropertyValue(fieldType.Name).GetPropertyValue("value") == value)
        {
            return true;
        }
    }
    return false;
}
Of course you need plenty of validation and work around the edges to make this safe but that's the gist of it.
