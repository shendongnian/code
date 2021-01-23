    // name your utility class how you want
    public static class MyEnumerable
    {
        /// <summary>
        /// Cuts a sequence into groups according to a specified key selector function.
        /// Similar to GroupBy, but only groups adjacent items.
        /// Reduces a collection a,a,B,B,B,a,c,c,c,c to (a,a),(B,B,B),(a),(c,c,c,c).
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">An <ref:System.Collections.Generic.IEnumerable/> whose elements to group.</param>
        /// <param name="keySelector"> A function to extract the key for each element.</param>
        /// <returns>
        /// An IEnumerable<IGrouping<TKey, TSource>> in C# or 
        /// IEnumerable(Of IGrouping(Of TKey, TSource)) in Visual Basic 
        /// where each <ref:System.Linq.IGrouping/> 2 object contains  a sequence of objects and a key.
        /// </returns>
        public static IEnumerable<IGrouping<TKey,TSource>> GroupAdjacentBy<TKey, TSource>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext()) yield break;
                var key = keySelector(e.Current);
                var elements = new List<TSource>();
                elements.Add(e.Current);
                while (e.MoveNext())
                {
                    var nextKey = keySelector(e.Current);
                    if (!Equals(nextKey, key))
                    {
                        yield return new Grouping<TKey, TSource>(key, elements);
                        key = nextKey;
                        elements = new List<TSource>();
                    }
                    elements.Add(e.Current);
                }
                yield return new Grouping<TKey, TSource>(key, elements);
            }
        }
        private class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
        {
            private TKey _key;
            private IEnumerable<TElement> _enumerable;
            public Grouping(TKey key, IEnumerable<TElement> enumerable)
            {
                _key = key;
                _enumerable = enumerable;
            }
            public TKey Key => _key;
            public IEnumerator<TElement> GetEnumerator() => _enumerable.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
