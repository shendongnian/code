    public static TResult PrePostMethod<T1, T2, TResult>(Func<T1, T2, TResult> someMethod, T1 a, T2 b)
    {
        Debug.Print("Pre");
        var result = someMethod(a, b);
        Debug.Print("Post");
        return result;
    }
