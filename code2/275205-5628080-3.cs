    public static class MultiComparer
    {
        public static MultiComparer<TSource> Create<TSource>(params IComparer<TSource>[] criterion)
        { return new MultiComparer<TSource>(criterion); }
    }
    public static class ProjectionComparer
    {
        public static ProjectionComparer<TSource, TKey> Create<TSource, TKey>(Func<TSource, TKey> keySelector)
        { return new ProjectionComparer<TSource, TKey>(keySelector); }
    }
    public sealed class MultiComparer<TSource>
        : IComparer<TSource>, System.Collections.IComparer
    {
        public MultiComparer(params IComparer<TSource>[] comparers)
        {
            this.criterion =
                comparers.Select(c => new Func<TSource, TSource, int>(c.Compare))
                         .ToArray();
        }
        private Func<TSource, TSource, int>[] criterion;
        public int Compare(TSource x, TSource y)
        {
            var cmp = 0;
            foreach (var compare in criterion)
                if ((cmp = compare(x, y)) != 0)
                    break;
            return cmp;
        }
        int System.Collections.IComparer.Compare(object x, object y)
        {
            return Compare((TSource)x, (TSource)y);
        }
    }
    public sealed class ProjectionComparer<TSource, TKey>
        : IComparer<TSource>, System.Collections.IComparer
    {
        public ProjectionComparer(Func<TSource, TKey> keySelector)
        {
            this.keySelector = keySelector;
            if (keyComparer == null) keyComparer = Comparer<TKey>.Default.Compare;
        }
        private Func<TSource, TKey> keySelector;
        private static Func<TKey, TKey, int> keyComparer = null;
        public int Compare(TSource x, TSource y)
        {
            return keyComparer(keySelector(x), keySelector(y));
        }
        int System.Collections.IComparer.Compare(object x, object y)
        {
            return Compare((TSource)x, (TSource)y);
        }
    }
