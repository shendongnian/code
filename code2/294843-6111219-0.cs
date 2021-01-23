    public static bool IsMixed(this object obj)
    {
        Type type = obj.GetType();
        PropertyInfo isThisProperty = type.GetProperty("IsThis", typeof(bool));
        PropertyInfo isThatProperty = type.GetProperty("IsThat", typeof(bool));
        if (isThisProperty != null && isThatProperty != null)
        {
            bool isThis = isThisProperty.GetValue(this, null);
            bool isThat = isThatProperty.GetValue(this, null);
            return isThis && isThat;
        }
        else
        {
            throw new ArgumentException(
                "Object must have properties IsThis and IsThat.",
                "obj"
            );
        }
    }
