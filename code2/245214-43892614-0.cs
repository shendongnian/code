    public static object GetDBNullOrValue<T>(this T val)
    {
        bool isDbNull = true;
        Type t = typeof(T);
    
        if (Nullable.GetUnderlyingType(t) != null)
            isDbNull = EqualityComparer<T>.Default.Equals(default(T), val);
        else if (t.IsValueType)
            isDbNull = false;
        else
            isDbNull = val == null;
    
        return isDbNull ? DBNull.Value : (object) val;
    }
