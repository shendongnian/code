    public static class JoinExtensions
    {
        public static U Join<T, U>(this T input, Func<T, U> project)
        {
            throw new InvalidOperationException("Can only be used in expression lambdas");
        }
        public static U Join<T, U>(this ICollection<T> input, Func<T, U> project)
        {
            throw new InvalidOperationException("Can only be used in expression lambdas");
        }
    }
