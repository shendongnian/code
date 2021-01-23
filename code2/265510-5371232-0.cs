    public static class EnumerableExtension
    {
        public static BigInteger Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, BigInteger> selector)
        {
            BigInteger output = 0;
    
            foreach(TSource item in source)
            {
                output += selector(item);
            }
    
            return output;
        }
    }
