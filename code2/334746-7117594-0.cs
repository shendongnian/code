    public static void IfNotNull<T>(this T obj, Action<T> act)
    {
        if(obj != null)
        {
            act(obj);
        }
    }
