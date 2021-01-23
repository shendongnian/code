    public static void SetParameterValue<T>(this Parameter param, T value)
    {
        param.Value = value;
        param.Type = typeof(T);
    }
