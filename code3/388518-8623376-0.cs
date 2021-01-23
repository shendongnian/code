    public static string ToIso8601FullDate(this DateTime? d)
    {
        if (!d.HasValue) return null;
        
        return d.Value.ToUniversalTime().ToString("yyyy-MM-dd");
    }
