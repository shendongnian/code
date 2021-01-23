    public void SetValue(TEnum property, object value)
    {
        bool equal = ((value != null) && value.GetType().IsValueType)
                         ? _properties[property].Equals(value)
                         : (_properties[property] == value);
        if (!equal)
        {
            // Only come here when the new value is different.
        }
    }
