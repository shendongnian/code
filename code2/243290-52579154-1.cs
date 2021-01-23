     public static class EnumerableHelpers 
     {
        public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> self, U init, Func<U, T, U> f) 
        {
            foreach (var x in self)
                yield return init = f(init, x);
        }
        public static IEnumerable<T> Accumulate<T>(this IEnumerable<T> self, Func<T, T, T> f)
        {
            return self.Accumulate(default(T), f);
        }
        public static IEnumerable<double> PartialSums(this IEnumerable<double> self)
        {
            return self.Accumulate((x, y) => x + y);
        }
        public static IEnumerable<int> PartialSums(this IEnumerable<int> self)
        {
            return self.Accumulate((x, y) => x + y);
        }
     }
