     public static class Conversion
        {
            public static T Read<T>(object Value, T DefaultValue = default(T))
            {
                if (Value is null || Value is DBNull)
                    return DefaultValue;
    
                return (T)Convert.ChangeType(Value, typeof(T));
            }
        }
