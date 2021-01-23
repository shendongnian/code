    // name your utility class how you want
    public static class MyEnumerable
    {
        /// <summary>
        /// Cuts a sequence into groups according to a specified key selector function.
        /// Similar to GroupBy, but only groups adjacent items.
        /// Reduces a collection a,a,B,B,B,a,p,p,p,p to (a,a),(B,B,B),(a),(p,p,p,p).
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">An <see cref="System.Collections.Generic.IEnumerable"/> whose elements to group.</param>
        /// <param name="keySelector"> A function to extract the key for each element.</param>
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; in C# or 
        /// IEnumerable(Of IGrouping(Of TKey, TSource)) in Visual Basic 
        /// where each <see cref="System.Linq.IGrouping"/> 2 object contains  a sequence of objects and a key.
        /// </returns>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacentBy<TKey, TSource>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            using (var en = source.GetEnumerator())
            {
                if (!en.MoveNext()) yield break;
                var key = keySelector(en.Current);
                var elements = new List<TSource> { en.Current };
                while (en.MoveNext())
                {
                    var nextKey = keySelector(en.Current);
                    if (!Equals(nextKey, key))
                    {
                        yield return new Grouping<TKey, TSource>(key, elements);
                        key = nextKey;
                        elements = new List<TSource>();
                    }
                    elements.Add(en.Current);
                }
                yield return new Grouping<TKey, TSource>(key, elements);
            }
        }
