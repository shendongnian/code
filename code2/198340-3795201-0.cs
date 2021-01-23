    public static void OutputValues<T>() where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new NotSupportedException("Argument must be an enum.");
        // code here...
    }
