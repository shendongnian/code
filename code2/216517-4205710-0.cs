    public static class SomeUtil {
        public static TSource MinBy<TSource, TValue>(
            this IEnumerable<TSource> source, Func<TSource, TValue> selector) {
            using (var iter = source.GetEnumerator())
            {
                if (!iter.MoveNext()) throw new InvalidOperationException("no data");
                var comparer = Comparer<TValue>.Default;
                var minItem = iter.Current;
                var minValue = selector(minItem);
                while (iter.MoveNext())
                {
                    var item = iter.Current;
                    var value = selector(item);
                    if (comparer.Compare(minValue, value) > 0)
                    {
                        minItem = item;
                        minValue = value;
                    }
                }
                return minItem;
            }
        }   
    }
