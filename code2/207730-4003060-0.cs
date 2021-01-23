    public static bool areBothNotNull<T>(T? p1, T? p2) where T : struct
    {            
        return (p1.HasValue && p2.HasValue);
    }
    
    public static bool areBothNotNull<T>(T p1, T p2)
    {
        return (p1 != null && p2 != null);
    }
