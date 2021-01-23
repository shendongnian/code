    public static T TryCast<T>(this object input)
    {
        if (input is T)
            return (T)input;
        return default(T);
    }
