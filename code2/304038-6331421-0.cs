    public static bool IsValid<T>(T propertyvalue)
    {
    	Type fieldType = Nullable.GetUnderlyingType(typeof(T));
    	if (object.ReferenceEquals(fieldType, typeof(bool))) {
            return true;
        }
    	return false;
    }
