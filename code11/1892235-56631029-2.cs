    public static bool HashIsTheSame(MulticastDelegate method1, MulticastDelegate method2, params object[] args)
    {
        object method1Result = method1.DynamicInvoke(args);
        object method2Result = method2.DynamicInvoke(args);
        return GetHashString(method1Result).Equals(method2Result);
    }
