    static class TestHelper
    {
        public static bool HashIsTheSame<TResult>(Func<TResult> method1,
            Func<TResult> method2) =>
            GetHashString(method1()).Equals(method2());
        public static bool HashIsTheSame<T, TResult>(Func<T, TResult> method1,
            Func<T, TResult> method2,
            T arg) =>
            GetHashString(method1(arg)).Equals(method2(arg));
        public static bool HashIsTheSame<T1, T2, TResult>(Func<T1, T2, TResult> method1,
            Func<T1, T2, TResult> method2,
            T1 arg1, T2 arg2) =>
            GetHashString(method1(arg1, arg2)).Equals(method2(arg1, arg2));
        public static bool HashIsTheSame<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> method1,
            Func<T1, T2, T3, TResult> method2,
            T1 arg1, T2 arg2, T3 arg3) =>
            GetHashString(method1(arg1, arg2, arg3)).Equals(method2(arg1, arg2, arg3));
        public static bool HashIsTheSame<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> method1,
            Func<T1, T2, T3, T4, TResult> method2,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
            GetHashString(method1(arg1, arg2, arg3, arg4)).Equals(method2(arg1, arg2, arg3, arg4));
        public static bool HashIsTheSame<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> method1,
            Func<T1, T2, T3, T4, T5, TResult> method2,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
            GetHashString(method1(arg1, arg2, arg3, arg4, arg5)).Equals(method2(arg1, arg2, arg3, arg4, arg5));
        // etc. Depends on what number of arguments you believe to make sense.
    }
