    static class Extensions
    {
        public static TResult CallDeconstructed<T1, T2, TResult>(this (T1, T2) tuple, Func<T1, T2, TResult> func)
        {
            return func(tuple.Item1, tuple.Item2);
        }
    }
