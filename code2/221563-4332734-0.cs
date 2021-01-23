    public static bool GenericEquals<T>(T v1, T v2)
    {
        if (v1 == null && v2 == null)
        {
            return true;
        }
        if (v1 == null || v2 == null)
        {
            return false;
        }
        return v1.Equals(v2);
    }
