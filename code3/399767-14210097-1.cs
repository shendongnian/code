    private string _getBackingFieldName(string propertyName)
    {
        return string.Format("<{0}>k__BackingField", propertyName);
    }
    
    private FieldInfo _getBackingField(object obj, string propertyName)
    {
        return obj.GetType().GetField(_getBackingFieldName(propertyName), BindingFlags.Instance | BindingFlags.NonPublic);
    }
