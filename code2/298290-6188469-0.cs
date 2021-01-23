    [Conditional("DEBUG")]
    public static void Print(string format, params object[] args)
    {
        TraceInternal.WriteLine(string.Format(CultureInfo.InvariantCulture, format, args));
    }
