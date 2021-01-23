    public static class IEnumerableExntesion
    {
        public IEnumerable<T> Except<T>(this IEnumerable<T> source, 
                                        IEnumerable<T> second, 
                                        Func<T, T, bool> predicate)
        {
            return source.Except(second, new PredicateEqualityComparer(predicate));
        }
    }    
