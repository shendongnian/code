        // credit: https://blogs.msdn.microsoft.com/ericlippert/2010/06/28/computing-a-cartesian-product-with-linq/
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> result = new[] { Enumerable.Empty<T>() };
            foreach (var sequence in sequences)
            {
                // got a warning about different compiler behavior
                // accessing sequence in a closure
                var s = sequence;
                result = result.SelectMany(seq => s, (seq, item) => seq.Concat<T>(new[] { item }));
            }
            return result;
        }
        public static void ConvertInPlace(this Array array, Func<object, object> projection)
        {
            if (array == null)
            {
                return;
            }
            // build up the range for each dimension
            var dimensions = Enumerable.Range(0, array.Rank).Select(r => Enumerable.Range(0, array.GetLength(r)));
            // build up a list of all possible indices
            var indexes = EnumerableHelper.CartesianProduct(dimensions).ToArray();
            foreach (var index in indexes)
            {
                var currentIndex = index.ToArray();
                array.SetValue(projection(array.GetValue(currentIndex)), currentIndex);
            }
        }
