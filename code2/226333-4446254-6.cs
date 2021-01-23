    public static partial class Specification
    {
        public static Expression<Func<T, bool>> All<T>(params Expression<Func<T, bool>>[] tail)
        {
            if (tail == null || tail.Length == 0) return _0 => true;
            var param = Expression.Parameter(typeof(T), "_0");
            var body = tail.Reverse()
                .Skip(1)
                .Aggregate((Expression)Expression.Invoke(tail.Last(), param),
                           (current, item) =>
                               Expression.AndAlso(Expression.Invoke(item, param),
                                                  current));
 
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }
