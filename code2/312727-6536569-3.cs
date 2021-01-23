    public static object DontReplaceIfNullOrEmpty(this object c, object d)
        {
            if(c is string)
                return !string.IsNullOrEmpty((string) c) ? c: d;
            return c ?? d;
        }
    object e = c.DontReplaceIfNull(d);
