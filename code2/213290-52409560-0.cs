    public static class SumExtensions
    {        
        public static Money Sum(this IEnumerable<Money> source)
            => source.Aggregate(new Money(0), (x, y) => x + y);
        public static Money Sum<T>(this IEnumerable<T> source, Func<T, Money> selector)
            => source.Select(selector).Sum();
    }
