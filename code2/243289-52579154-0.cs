     public static class EnumerableHelpers 
     {
        public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> self, U init, Func<U, T, U> f) 
        {
            foreach (var x in self)
                yield return init = f(init, x);
        }
        public static IEnumerable<double> PartialSums(this IEnumerable<double> self)
        {
            return self.Accumulate(0.0, (x, y) => x + y);
        }
     }
