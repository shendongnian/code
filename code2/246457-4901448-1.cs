    public static T TryCast<T>(this object input)
    {
        bool success;
        return TryCast<T>(input, out success);
    }
