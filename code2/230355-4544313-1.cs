    public static string GenerateDateString(DateTime value)
    {
        return string.Format(
            "{0} {1:MMMM}",
            ToOrdinal(value.Day),
            value);            
    }
