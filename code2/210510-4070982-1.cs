    var listdiff = list1.Except(list2, x => x.Id, y => y.Id);
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<TFirst> Except<TFirst, TSecond, TKey>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TKey> firstKeySelector,
            Func<TSecond, TKey> secondKeySelector)
        {
            // argument null checking etc omitted for brevity
            var keys = new HashSet<TKey>(second.Select(secondKeySelector));
            return first.Where(x => keys.Add(firstKeySelector(x)));
        }
    }
