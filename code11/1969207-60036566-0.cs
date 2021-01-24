        /// <summary>
        /// Full join without returning null values.
        /// MoreLinq - https://github.com/morelinq/MoreLINQ/blob/master/MoreLinq/FullJoin.cs
        /// </summary>
        public static IEnumerable<TResult> FullJoinExceptNull<TFirst, TSecond, TKey, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TKey> firstKeySelector,
            Func<TSecond, TKey> secondKeySelector,
            Func<TFirst, TResult> firstSelector,
            Func<TSecond, TResult> secondSelector,
            Func<TFirst, TSecond, TResult> bothSelector,
            IEqualityComparer<TKey> comparer = null)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (firstKeySelector == null) throw new ArgumentNullException(nameof(firstKeySelector));
            if (secondKeySelector == null) throw new ArgumentNullException(nameof(secondKeySelector));
            if (firstSelector == null) throw new ArgumentNullException(nameof(firstSelector));
            if (secondSelector == null) throw new ArgumentNullException(nameof(secondSelector));
            if (bothSelector == null) throw new ArgumentNullException(nameof(bothSelector));
            return _(); IEnumerable<TResult> _()
            {
                var seconds = second.Select(e => new KeyValuePair<TKey, TSecond>(secondKeySelector(e), e)).ToArray();
                var secondLookup = seconds.ToLookup(e => e.Key, e => e.Value, comparer);
                var firstKeys = new HashSet<TKey>(comparer);
                foreach (var fe in first)
                {
                    var key = firstKeySelector(fe);
                    firstKeys.Add(key);
                    using var se = secondLookup[key].GetEnumerator();
                    if (se.MoveNext())
                    {
                        do 
                        {
                            var result = bothSelector(fe, se.Current);
                            if (result == null) continue;
                            yield return result; 
                        }
                        while (se.MoveNext());
                    }
                    else
                    {
                        se.Dispose();
                        yield return firstSelector(fe);
                    }
                }
                foreach (var se in seconds)
                {
                    if (!firstKeys.Contains(se.Key))
                        yield return secondSelector(se.Value);
                }
            }
        }
