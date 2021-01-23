    public static string EmptyToNull(this string obj)
    {
        return obj == string.Empty ? null : obj;
    }
    
    public static T? EmptyToNull<T>(this T obj) where T : struct
    {
        return obj.Equals(default(T)) ? default(T?) : obj;
    }
    
    public static T? EmptyToNull<T>(this T? obj) where T : struct
    {
        return obj == null ? obj : EmptyToNull(obj.Value);
    }
