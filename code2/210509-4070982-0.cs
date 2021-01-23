    var listdiff = list1.Except(list2, x => x.Id, x => x.Id);
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<TLeft> Except<TLeft, TRight, TLeftKey, TRightKey>(
            this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TLeftKey> leftKeySelector,
            Func<TRight, TRightKey> rightKeySelector)
        {
            // argument null checking etc omitted for brevity
            var keys = new HashSet<TRightKey>(right.Select(rightKeySelector));
            return left.Where(x => keys.Add(leftKeySelector(x)));
        }
    }
