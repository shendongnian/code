    public object ConvertType(object value, Type conversionType)
    {
        //Check if type is Nullable
        if (conversionType.IsGenericType &&
            conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            //If the type is Nullable and the value is null
            //Just return null
            if (value == null)
            {
                return null;
            }
            //Type is Nullable and we have a value, override conversion type to underlying
            //type for the Nullable to avoid exception in Convert.ChangeType
            var nullableConverter = new NullableConverter(conversionType);
            conversionType = nullableConverter.UnderlyingType;
        }
        return Convert.ChangeType(value, conversionType);
    }
