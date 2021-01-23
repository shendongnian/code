    public static class EnumerableDoubleExtensions {
        public static double Product(this IEnumerable<double> source) {
            Contract.Requires(source != null);
            return source.Aggregate(1d, (p, x) => p * x);
         }
    }
