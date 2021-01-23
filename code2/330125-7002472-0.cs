    public static bool CannotBeCastAs<T>(this object actual)
        where T: class
    {
        return (actual as T == null);
    }
