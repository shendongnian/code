    public static class EnumerableDoubleExtensions {
        public static double SumSquares(this IEnumerable<double> source) {
            Contract.Requires(source != null);
            return source.Sum(x => x * x);
         }
    }
