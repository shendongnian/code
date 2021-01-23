    namespace My.Core.Extensions
    {
        public static class EnumerableHelper<E>
        {
            private static Random r;
    
            static EnumerableHelper()
            {
                r = new Random();
            }
    
            public static T Random<T>(IEnumerable<T> input)
            {
                return input.ElementAt(r.Next(input.Count()));
            }
    
        }
    
        public static class EnumerableExtensions
        {
            public static T Random<T>(this IEnumerable<T> input)
            {
                return EnumerableHelper<T>.Random(input);
            }
        }
    }
