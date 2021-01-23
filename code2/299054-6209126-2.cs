    public void SetValue(TEnum property, object value)
    {
        bool equal = ((value != null) && value.GetType().IsValueType)
                         ? value.Equals(_properties[property])
                         : (value == _properties[property]);
        if (!equal)
        {
            // Only come here when the new value is different.
        }
    }
